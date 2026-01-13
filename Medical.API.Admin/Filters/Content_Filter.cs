using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Medical.Api.Admin.Filters
{
    /// <summary>
    /// 评论内容过滤器
    /// </summary>
    public class Content_Filter : ActionFilterAttribute
    {
        // 词库字典
        private readonly Dictionary<string, List<string>> _wordLibraries;

        // URL正则表达式
        private readonly Regex _urlRegex;

        // 电话号码正则表达式
        private readonly Regex _phoneRegex;

        // 数据文件夹路径
        private readonly string _dataFolderPath;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="env"></param>
        public Content_Filter(IWebHostEnvironment env)
        {
            _dataFolderPath = Path.Combine(env.WebRootPath, "Filter_Words");
            // 初始化所有词库
            _wordLibraries = new Dictionary<string, List<string>>
            {
                { "广告词", LoadWordsFromFile("advertising_words.txt") },
                { "反动词", LoadWordsFromFile("reaction_words.txt") },
                { "色情词", LoadWordsFromFile("porn_words.txt") },
                { "贪腐词", LoadWordsFromFile("corruption_words.txt") },
                { "毒品词", LoadWordsFromFile("drug_words.txt") },
                { "暴恐词", LoadWordsFromFile("terror_words.txt") },
                { "其他违规词", LoadWordsFromFile("key.txt") },
                { "脏话词", LoadWordsFromFile("curse_words.txt") },
                { "网站词", LoadWordsFromFile("web_words.txt") },
                { "违规词2", LoadWordsFromFile("other2.txt") },
                { "违规词3", LoadWordsFromFile("other3.txt") },
            };
            // URL和电话正则
            _urlRegex = new Regex(@"(http|https)://[^\s]+", RegexOptions.Compiled);
            _phoneRegex = new Regex(@"1[3-9]\d{9}", RegexOptions.Compiled);
        }

        private List<string> LoadWordsFromFile(string fileName)
        {
            var filePath = Path.Combine(_dataFolderPath, fileName);

            if (!File.Exists(filePath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToList();
        }
       /// <summary>
       /// 执行动作过滤器
       /// </summary>
       /// <param name="context"></param>
       /// <param name="next"></param>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // 获取评论内容
            if (!context.ActionArguments.TryGetValue("content", out var contentObj) || 
                contentObj is not string content)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    code = -1,
                    message = "缺少评论内容参数"
                });
                return;
            }

            var result = CheckContent(content);

            if (!result.IsValid)
            {
                context.Result = new OkObjectResult(new
                {
                    code = -1,
                    message = $"评论包含违规内容，原因：{result.RejectReason}",
                    detail = result.DetectedWords
                });
                return;
            }

            await base.OnActionExecutionAsync(context,next);
        }
       /// <summary>
       /// 检查评论内容
       /// </summary>
       /// <param name="content"></param>
       /// <returns></returns>
        public ContentCheckResult CheckContent(string content)
        {
            var result = new ContentCheckResult { IsValid = true };

            if (string.IsNullOrWhiteSpace(content))
            {
                result.IsValid = false;
                result.RejectReason = "评论内容不能为空";
                return result;
            }

            foreach (var library in _wordLibraries)
            {
                var foundWords = library.Value
                    .Where(word => content.Contains(word))
                    .ToList();

                if (foundWords.Any())
                {
                    result.IsValid = false;
                    result.RejectReason = $"包含{library.Key}内容";
                    result.DetectedWords.AddRange(foundWords);
                }
            }

            if (_urlRegex.IsMatch(content))
            {
                result.IsValid = false;
                result.RejectReason = "不能包含网址链接";
                result.DetectedWords.Add("URL");
            }

            if (_phoneRegex.IsMatch(content))
            {
                result.IsValid = false;
                result.RejectReason = "不能包含电话号码";
                result.DetectedWords.Add("Phone");
            }

            if (content.Count(c => "!@#$%^&*".Contains(c)) > 5)
            {
                result.IsValid = false;
                result.RejectReason = "包含过多特殊符号";
            }

            return result;
        }
    }
   /// <summary>
   /// 评论内容检查结果
   /// </summary>
    public class ContentCheckResult
    {
        /// <summary>
        /// 是否合法
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 拒绝原因
        /// </summary>
        public string RejectReason { get; set; } = string.Empty;
        /// <summary>
        /// 违规词
        /// </summary>
        public List<string> DetectedWords { get; set; } = new List<string>();
    }
}