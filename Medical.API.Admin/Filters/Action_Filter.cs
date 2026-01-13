//using System.Reflection;
//using System.Security.Claims;
//using System.Text;
//using Goods.Infrastructure.EFCore.MySql.Models;
//using Medical.Infrastructure.Attr;
//using Medical.Infrastructure.Tools;
//using Medical.Service.Interface;
//using Medical.Service.Interface.Admin.Service;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace Medical.Api.Admin.Filters;

///// <summary>
///// 
///// </summary>
//public class Action_Filter : Base_Filter
//{
//    private readonly I_System_Service _system_service;

//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="login_service"></param>
//    /// <param name="system_service"></param>
//    public Action_Filter(I_Org_Service login_service, I_System_Service system_service) : base(login_service)
//    {
//        _system_service = system_service;
//    }

//    /// <summary>
//    ///  
//    /// </summary>
//    /// <param name="context"></param>
//    /// <param name="next"></param>
//    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
//    {
//        //判断是否存在Action_Attribute属性

//        //记录日志 

//        var action = context.ActionDescriptor as ControllerActionDescriptor;
//        var attr = action!.MethodInfo.GetCustomAttribute<Action_Attribute>(); //获取日志特性
//        if (attr == null)
//        {
//            //没有该属性 则无需记录日志
//            await base.OnResultExecutionAsync(context, next);
//            return;
//        }

//        string paras = "";
//        string method = context.HttpContext.Request.Method.ToUpper();
//        if (context.HttpContext.Request.Method.ToUpper() == "GET")
//        {
//            var keys = context.HttpContext.Request.Query.Keys;
//            foreach (var item in keys)
//            {
//                paras += $"{item}={context.HttpContext.Request.Query[item]};";
//            }
//        }
//        else
//        {
//            var request = context.HttpContext.Request;
//            request.EnableBuffering();
//            if (request.Method.ToLower().Equals("post"))
//            {
//                request.Body.Seek(0, SeekOrigin.Begin);
//                using var reader = new StreamReader(request.Body, Encoding.UTF8);
//                paras = await reader.ReadToEndAsync();
//            }
//        }

//        paras = paras.Length > 999 ? paras.Substring(0, 999) : paras;

//        string url = context.HttpContext.Request.Path;
//        var code = context.HttpContext.User.Identity?.Name; //NAME=Code 
//        var actorClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor);
//        if (actorClaim == null)
//        {
//            throw new UnauthorizedAccessException("用户身份信息缺失");
//        }
//        string account = actorClaim!.Value;
//        var user = Get_Curr_Employee(context, account,code!);

//        //通过attribute 来获取
//        //先执行 Action，再获取返回结果
//        /*var executed_context = await next(); */// 执行 Action 并获取执行后的上下文

//        int status_code = context.HttpContext.Response.StatusCode;
//        int al_result = (status_code == 200) ? 1 : 0;
//        _system_service.Add_Action_Logs(new SysActionLog
//        {
//            Alid = Config.GUID(),
//            AlGroup = attr.Group,
//            AlAction = attr.Action,
//            AlCreateTime = DateTime.Now,
//            AlUid = user?.id,
//            AlParams = paras,
//            AlIp = Config.GetIp(),
//            AlUrl = url,
//            Alresult = al_result,
//            AlMethod = method
//        });

//        await base.OnResultExecutionAsync(context, next);
//    }
//}