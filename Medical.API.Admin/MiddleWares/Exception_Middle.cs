//using System.Security.Claims;
//using System.Text;
//using Goods.Infrastructure.EFCore.MySql.Models;
//using Medical.Infrastructure.Tools;
//using Medical.Service.Interface;
//using Medical.Service.Interface.Admin.Service;

//namespace Medical.Api.Admin.MiddleWares;

///// <summary>
///// 全局错误处理
///// </summary>
//public class Exception_Middle
//{
//    private readonly RequestDelegate _next;
//    private readonly IConfiguration _configuration;

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="configuration"></param>
//    /// <param name="next"></param>
//    public Exception_Middle(IConfiguration configuration, RequestDelegate next)
//    {
//        _configuration = configuration;
//        _next = next;
//    }

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="context"></param>
//    /// <param name="log_service"></param>
//    /// <param name="login_service"></param>
//    public async Task InvokeAsync(HttpContext context, I_System_Service log_service,I_Org_Service login_service)
//    {
//        try
//        {
//            await _next(context);
//        }
//        catch (Exception ex)
//        {
//            string _parmas = "";
//            if (context.Request.Method.ToUpper() == "GET")
//            {
//                var keys = context.Request.Query.Keys;
//                foreach (var item in keys)
//                {
//                    _parmas += $"{item}={context.Request.Query[item]};";
//                }
//            }
//            else
//            {
//                var request = context.Request;
//                request.EnableBuffering();
//                if (request.Method.ToLower().Equals("post"))
//                {
//                    request.Body.Seek(0, SeekOrigin.Begin);
//                    using var reader = new StreamReader(request.Body, Encoding.UTF8);
//                    _parmas = await reader.ReadToEndAsync();
//                    request.Body.Seek(0, SeekOrigin.Begin); // 重置流位置
//                }
//            }
//            //获取操作员工信息
//            var eids = "";
//            var account = "";
//            var code = context.User.Identity?.Name;
//            var actorClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor);
//            var account_ = string.Empty;
//            if (actorClaim != null)
//            {
//                 account_ = actorClaim!.Value;
//            }
//            var employee = login_service.Check_Login(code,account_);
//            eids = employee?.id ?? "未进入系统";
//            account = employee?.account ?? "未进入系统";

//            var path = _configuration["LogPath"]; //获取日志路径
//            path += $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt";

//            var new_parmas = "";
//            if (_parmas.IndexOf("password") > -1)
//            {
//                var index = _parmas.IndexOf("password");
//                new_parmas = _parmas.Substring(index + 12);
//                var end_index = new_parmas.IndexOf("\"");

//                new_parmas = new_parmas.Substring(end_index);
//                for (int i = 0; i < end_index; i++)
//                {
//                    new_parmas = "*" + new_parmas;
//                }

//                _parmas = _parmas.Substring(0, index + 12) + new_parmas;
//            }

//            try
//            {
//                var message = $"发生时间：{DateTime.Now.ToString()}\r\n" + $"请求地址：{context.Request.Path}\r\n" +
//                              $"请求方式：{context.Request.Method.ToUpper()}\r\n" +
//                              $"操作用户：{eids+'/'+(account)}\r\n" +
//                              $"请求参数：{_parmas}\r\n" +
//                              $"请求消息：{ex.Message}\r\n\r\n";
//                //记录到本地日志文件中
//                await System.IO.File.AppendAllTextAsync(path, message);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }

//            try
//            {
//                log_service.Add_Error_Logs(new SysErrorLog
//                {
//                    Elid = Config.GUID(),
//                    Elmessage = ex.Message,
//                    ElUrl = context.Request.Path,
//                    ElMethod = context.Request.Method.ToUpper(),
//                    ElParams = _parmas.Length > 999 ? _parmas.Substring(0, 999) : _parmas,
//                    ElcreateTime = DateTime.Now,
//                    Eluid = eids,
//                    ElIp = Config.GetIp(),
//                });
//            }
//            catch
//            {
//                await System.IO.File.AppendAllTextAsync(path, $"时间：{DateTime.Now.ToString()}\r\n记录日志到数据库失败");
//                throw;
//            }
//            context.Response.StatusCode = 500;
//            await context.Response.WriteAsync("system error");
//        }
//    }
//}