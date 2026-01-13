//using System.Security.Claims;
//using Medical.Infrastructure.Dto.Response.Org;
//using Medical.Infrastructure.Dto.Response.Org.Employee;
//using Medical.Service.Interface;
//using Medical.Service.Interface.Admin.Service;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace Medical.Api.Admin.Filters;

///// <summary>
///// 基础过滤器
///// </summary>
//public class Base_Filter:ActionFilterAttribute
//{
//    private readonly I_Org_Service _orgLogin_service;

//    /// <summary>
//    /// 构造函数
//    /// </summary>
//    /// <param name="orgService"></param>
//    public Base_Filter(I_Org_Service orgService)
//    {
//        _orgLogin_service = orgService;
//    }
//    /// <summary>
//    /// 获取当前用户
//    /// </summary>
//    /// <returns></returns>
//    protected Employee_Response_Dto Get_Curr_Employee(FilterContext context,string account,string code)
//    {
//        var actorClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor);
//        if (actorClaim == null)
//        {
//            throw new UnauthorizedAccessException("用户身份信息缺失");
//        }
//        var account_ = actorClaim!.Value ?? account;
//        var employee = _orgLogin_service.Check_Login(code!,account_);
//        if (employee == null)
//        {
//            throw new Exception("登录已过期");
//        }
//        return employee;
//    }
//}