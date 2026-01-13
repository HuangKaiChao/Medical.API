using Medical.Infrastructure.Attr;
using Medical.Infrastructure.Dto.Request.Customer.Admin_Customer;
using Medical.Infrastructure.Dto.Request.Customer.isBan_Customer;
using Medical.Infrastructure.Dto.Request.Employee.Add_Admin;
using Medical.Infrastructure.Dto.Request.Employee.Revise_Admin;
using Medical.Infrastructure.Dto.Request.Org.Employee;
using Medical.Infrastructure.Dto.Response;
using Medical.Infrastructure.Dto.Response.Org.Employee;

namespace Medical.Service.Interface.Admin.Service
{
    [Provider_]
    public interface I_Org_Service
    {
        /// <summary>
        /// 管理端-员工登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Logins(Employee_Login_Request_Dto dto);

        /// <summary>
        /// 管理端-获取当前登录员工
        /// </summary>
        /// <param name="code"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        Employee_Response_Dto Check_Login(string? code, string account);

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <returns></returns>
        Task<Api_Response_Dto> Add_Admin(Add_Admin_Request_Dto dto);

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Delete_Admin(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Api_Response_Dto> Get_All_Admins();


        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Revise_Admin(Revise_Admin_Request_Dto dto);


        /// <summary>
        /// 禁用员工
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> isBan_Admin(isBan_Admin_Request_Dto dto);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        Task<Api_Response_Dto?> Get_Department_List();


        /// <summary>
        /// 获取职务列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Get_Duty_List(Get_Duty_List_Request_Dto dto);

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Add_Dept(Add_Dept_Request_Dto dto);

        /// <summary>
        /// 获取单个部门职务列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Get_Single_Dept_Duty(string id);
    }
}
