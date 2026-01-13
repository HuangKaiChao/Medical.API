using Medical.Api.Admin.Controllers;
using Medical.Api.Admin.Filters;
using Medical.Infrastructure.Dto.Request.Customer.Admin_Customer;
using Medical.Infrastructure.Dto.Request.Employee.Add_Admin;
using Medical.Infrastructure.Dto.Request.Employee.Revise_Admin;
using Medical.Infrastructure.Dto.Request.Module;
using Medical.Infrastructure.Dto.Request.Org.Employee;
using Medical.Infrastructure.Dto.Response;
using Medical.Infrastructure.Dto.Response.Org.Employee;
using Medical.Infrastructure.Tools;
using Medical.Service.Interface.Admin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medical.API.Admin.Controllers.Admin.Controllers
{
    /// <summary>
    /// 管理端-组织架构-控制器
    /// </summary>
    public class OrgController : BaseController
    {
        private readonly I_Org_Service _org_Service;
        private readonly IConfiguration _configuration;

        public OrgController(I_Org_Service org_Service,
            IConfiguration configuration)
        {
            _org_Service = org_Service;
            _configuration = configuration;
        }

        /// <summary>
        /// 管理端-组织架构-员工登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logins(Employee_Login_Request_Dto dto)
        {
            dto.code = Config.GUID();
            var result = await _org_Service.Logins(dto);
            //登录成功
            if (result!.code == Infrastructure.Dto.Response.Api_Code.ok)
            {
                //登录成功生成凭据
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, dto.code),
                new Claim(ClaimTypes.Actor, dto.account!.Trim()),
                new Claim(ClaimTypes.Role, "admin")
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                string jwtKey = _configuration["JWT:issuer"]!;
                var token = new JwtSecurityToken(issuer: jwtKey, audience: jwtKey, claims: claims,
                    expires: DateTime.Now.AddMinutes(60 * 12), //token 过期时间
                    signingCredentials: creds);
                result.data = new { token = new JwtSecurityTokenHandler().WriteToken(token), code = dto.code, };
            }

            return Ok(result);
        }
        /// <summary>
        /// 管理端-组织架构-获取当前登录的员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Result_Filter]
        [Authorize(Roles = "admin")]
        public IActionResult Check_Login()
        {
            var employee = Get_Current_Employee();
            if (employee == null!)
            {
                return Unauthorized();
            }

            return Ok(new Api_Response_Dto()
            {
                code = 0,
                message = "ok",
                data = new
                {
                    name = employee.name,
                    account = employee.account,
                    avatar = employee.avatar
                },
            });
        }

        /// <summary>
        /// 管理端-组织架构-获取当前登录的员工信息
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Employee_Response_Dto Get_Current_Employee()
        {
            var code = Response.HttpContext.User.Identity?.Name;
            var actorClaim = Response.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor);
            var account = actorClaim!.Value;
            var employee = _org_Service.Check_Login(code, account!);
            if (employee == null)
            {
                throw new Exception("登录已过期");
            }
            return employee;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Result_Filter]
        public async Task<IActionResult> Add_Admin(Add_Admin_Request_Dto dto)
        {
            var result = await _org_Service.Add_Admin(dto);
            return Ok(result);
        }

        /// <summary>
        /// 获取全部管理员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get_All_Admins()
        {
            var result = await _org_Service.Get_All_Admins();
            return Ok(result);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete_Admin([FromForm] string id)
        {
            var result = await _org_Service.Delete_Admin(id);
            return Ok(result);
        }

        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Revise_Admin(Revise_Admin_Request_Dto dto)
        {
            var result = await _org_Service.Revise_Admin(dto);
            return Ok(result);
        }

        /// <summary>
        /// 禁用员工
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Result_Filter]
        public async Task<IActionResult> isBan_Admin(isBan_Admin_Request_Dto dto)
        {
            var result = await _org_Service.isBan_Admin(dto);
            return Ok(result);
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add_Dept(Add_Dept_Request_Dto dto)
        {
            var result = await _org_Service.Add_Dept(dto);
            return Ok(result);
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get_Department_List()
        {
            var result = await _org_Service.Get_Department_List();
            return Ok(result);
        }

        /// <summary>
        /// 获取职务列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get_Duty_List(Get_Duty_List_Request_Dto dto)
        {
            var result = await _org_Service.Get_Duty_List(dto);
            return Ok(result);
        }


        /// <summary>
        /// 获取单个部门的职务列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get_Single_Dept_Duty(string id)
        {
            var result = await _org_Service.Get_Single_Dept_Duty(id);
            return Ok(result);
        }
    }
}
