namespace Medical.Infrastructure.Tools;

/// <summary>
/// 专属推广码生成器
/// 使用方式：var code = ExclusivePromoCodeGenerator.Generate(6);
/// </summary>
public class ExclusivePromoCodeGenerator
{
    /// <summary>
    /// 专属推广码生成器
    /// 支持指定长度，确保唯一性和业务可读性
    /// </summary>
        // 线程安全锁
        private static readonly object _syncLock = new object();
        
        // 已生成的推广码缓存（用于内存级去重校验）
        private static readonly HashSet<string> _generatedCodes = new HashSet<string>();
        
        // 默认字符集：排除易混淆字符（0/O、1/I、L）
        private const string DefaultChars = "23456789ABCDEFGHJKLMNPQRSTUVWXYZ";

        /// <summary>
        /// 生成指定长度的专属推广码
        /// </summary>
        /// <param name="length">推广码长度（建议6-10位）</param>
        /// <param name="charset">自定义字符集（null则使用默认字符集）</param>
        /// <returns>唯一的推广码字符串</returns>
        /// <exception cref="ArgumentOutOfRangeException">长度不符合要求时抛出</exception>
        public static string Generate(int length, string charset = null)
        {
            // 校验长度合理性（太短易重复，太长难记忆）
            if (length < 4 || length > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "推广码长度应在4-16位之间");
            }

            // 使用默认字符集或自定义字符集
            var charSet = string.IsNullOrEmpty(charset) ? DefaultChars : charset;
            if (charSet.Length < 2)
            {
                throw new ArgumentException("字符集至少包含2个不同字符", nameof(charset));
            }

            lock (_syncLock)
            {
                string promoCode;
                var random = new Random();
                
                // 循环生成直到获得未重复的推广码
                do
                {
                    var codeBuilder = new char[length];
                    for (int i = 0; i < length; i++)
                    {
                        // 从字符集中随机选择字符
                        codeBuilder[i] = charSet[random.Next(charSet.Length)];
                    }
                    promoCode = new string(codeBuilder);
                    
                    // 增加校验：避免全数字或全字母（提升可读性）
                } while (_generatedCodes.Contains(promoCode) || IsAllDigits(promoCode) || IsAllLetters(promoCode));

                // 加入缓存记录
                _generatedCodes.Add(promoCode);
                return promoCode;
            }
        }

        /// <summary>
        /// 批量生成推广码
        /// </summary>
        /// <param name="count">生成数量</param>
        /// <param name="length">每个推广码的长度</param>
        /// <returns>推广码列表</returns>
        public static List<string> GenerateBatch(int count, int length)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "生成数量必须大于0");
            
            var result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                // 加入随机延迟避免高并发下的随机数重复
                System.Threading.Thread.Sleep(1);
                result.Add(Generate(length));
            }
            return result;
        }

        /// <summary>
        /// 验证推广码是否已存在
        /// </summary>
        public static bool Exists(string promoCode)
        {
            if (string.IsNullOrEmpty(promoCode))
                return false;
                
            lock (_syncLock)
            {
                return _generatedCodes.Contains(promoCode);
            }
        }

        /// <summary>
        /// 从缓存中移除推广码（用于回收或失效处理）
        /// </summary>
        public static bool Remove(string promoCode)
        {
            lock (_syncLock)
            {
                return _generatedCodes.Remove(promoCode);
            }
        }

        // 辅助方法：判断是否全为数字
        private static bool IsAllDigits(string value)
        {
            return value.All(char.IsDigit);
        }

        // 辅助方法：判断是否全为字母
        private static bool IsAllLetters(string value)
        {
            return value.All(char.IsLetter); 
        }
}