using System.Net;
using Medical.Infrastructure.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Medical.Api.Admin.Filters;

/// <summary>
/// 结果过滤器，用于统一API响应格式
/// </summary>
public class Result_Filter : ActionFilterAttribute
{
    /// <summary>
    /// 执行结果过滤
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        // 先将context.Result转换为ObjectResult并赋值给变量
        var objectResult = context.Result as ObjectResult;
        
        // 处理权限拒绝的情况
        if (objectResult != null && 
            objectResult.Value is Api_Response_Dto forbiddenResult && 
            (int)forbiddenResult.code == (int)HttpStatusCode.Forbidden)
        {
            context.Result = new OkObjectResult(new
            {
                code = HttpStatusCode.Forbidden,
                message = forbiddenResult.message
            });
            return base.OnResultExecutionAsync(context, next);
        }
        
        // 检查是否是Api_Response_Dto类型的结果
        if (objectResult != null && objectResult.Value is Api_Response_Dto apiResult)
        {
            // 根据data是否为null创建不同的匿名对象
            if (apiResult.data == null)
            {
                // data为null时，只返回code和message
                context.Result = new OkObjectResult(new
                {
                    code = apiResult.code,
                    message = apiResult.message
                });
            }
            else
            {
                // data不为null时，返回全部三个字段
                context.Result = new OkObjectResult(new
                {
                    code = apiResult.code,
                    message = apiResult.message,
                    data = apiResult.data
                });
            }
        }
        
        return base.OnResultExecutionAsync(context, next);
    }
}
