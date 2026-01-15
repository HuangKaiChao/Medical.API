using Medical.Infrastructure.Attr;
using Medical.Infrastructure.Dto.Request.Customer.Admin_Customer;
using Medical.Infrastructure.Dto.Request.Employee.Add_Admin;
using Medical.Infrastructure.Dto.Request.Employee.Revise_Admin;
using Medical.Infrastructure.Dto.Request.Org.Employee;
using Medical.Infrastructure.Dto.Response;
using Medical.Infrastructure.Dto.Response.Customer.Admin_Customer;
using Medical.Infrastructure.Dto.Response.Org.Employee;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Infrastructure.IOC;
using Medical.Infrastructure.Tools;
using Medical.Service.Interface.Admin.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Medical.Service.Instance.Admin.Service
{
    [Inject_]
    public class Org_Service : Base_Service, I_Org_Service
    {
        private readonly Org_IOC _org_IOC;
        private readonly IConfiguration _configuration;
        private readonly Rights_IOC _rights_IOC;

        public Org_Service(Org_IOC org_IOC,
            IConfiguration configuration,
            Rights_IOC rights_IOC)
        {
            _org_IOC = org_IOC;
            _configuration = configuration;
            _rights_IOC = rights_IOC;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="dto"></param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns></returns>
        public async Task<Api_Response_Dto> Add_Admin(Add_Admin_Request_Dto dto)
        {
            var isExist = await _org_IOC._employeeLogin_EFCore.QueryAll(e => e.Eaccount == dto.account).AnyAsync();
            if (isExist)
            {
                return Get_Result(-1, "账号已存在");
            }
            var salt = Config.GUID();
            var pwd = EncryptUtil.LoginMd5(dto.password!, salt);
            var add_employee = new OrgEmployee()
            {
                Eid = Config.GUID2(),
                Eaccount = dto.account!,
                Epassword = pwd,
                Ename = dto.name!,
                Enick = dto.nick,
                Esalt = salt,
                Eavatar = dto.avatar,
                Egender = dto.gender,   
                Eemail = dto.email,
                EentryDate = DateTime.Now,
                Eexplain = dto.explain,
                EdeptId = dto.dept_id!,
                EdutyId = dto.duty_id!,
                ErolesId = "",
                Especialty = "",
                Estatus = 1,
                EisOnline = 0,
                EisActive = 0,
                EisBan = 0,
                EcreateTime = DateTime.Now,
            };
            await _org_IOC._employeeLogin_EFCore.AddAsync(add_employee);
            await _rights_IOC._sysEmployeeRoles_EFCore.AddRangeAsync(dto.role_ids!.Select(r => new SysEmployeeRole()
            {
                Erid = Config.GUID2(),
                Ereid = add_employee.Eid,
                Errid = r,
                ErcreateTime = DateTime.Now,
            }).ToList());
            var result = await _rights_IOC._sysEmployeeRoles_EFCore.TransactionsAsync(_rights_IOC._sysEmployeeRoles_EFCore);
            return Get_Result(result ? 1 : -1, result ? "ok" : "fail");
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Api_Response_Dto> Add_Dept(Add_Dept_Request_Dto dto)
        {
            if (string.IsNullOrEmpty(dto.name))
            {
                return Get_Result(-1, "部门名称不能为空");
            }

            if (!string.IsNullOrEmpty(dto.parent_id))
            {
                var parentDeptQuery = _org_IOC._orgDepartments_EFCore.QueryAll(d => d.DparentId == dto.parent_id);

                var existsParentDept = await parentDeptQuery.AnyAsync();

                if (existsParentDept)
                {
                    return Get_Result(-1, "部门父级id不能为空");
                }
            }
            if (string.IsNullOrEmpty(dto.icon))
            {
                return Get_Result(-1, "部门图标不能为空");
            }
            if (dto.dids!.Count == 0)
            {
                return Get_Result(-1, "部门岗位不能为空");
            }

            var newDept = new OrgDepartment()
            {
                Did = Config.GUID2(),
                Dname = dto.name!,
                DparentId = dto.parent_id,
                Dicon = dto.icon,
                DsortOrder = dto.level,
                Ddescription = dto.explain,
                DcreateTime = DateTime.Now,
                DisBan = 0,
            };

            await _org_IOC._orgDepartments_EFCore.AddAsync(newDept);
            await _org_IOC._orgDepartmentDutys_EFCore.AddRangeAsync(dto.dids!.Select(d => new OrgDepartmentDuty()
            {
                Ddid = Config.GUID2(),
                DddeptId = newDept.Did,
                DddutyId = d,
                DdcreateTime = DateTime.Now,
            }).ToList());
            var result = await _org_IOC._orgDepartments_EFCore.TransactionsAsync(_org_IOC._orgDepartmentDutys_EFCore);
            return Get_Result(result ? 1 : -1, result ? "ok" : "fail");
        }

        public Employee_Response_Dto Check_Login(string? code, string account)
        {
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(code))
            {
                return null; // 参数无效，返回空（表示校验失败）
            }

            var iq = _org_IOC._employeeLogin_EFCore.QueryAll(d => d.Eaccount == account).FirstOrDefaultAsync();
            if (iq == null)
            {
                return null;
            }

            return new Employee_Response_Dto
            {
                id = iq.Result!.Eid,
                name = iq.Result.Ename,
                nick = iq.Result.Enick,
                account = iq.Result.Eaccount,
                avatar = iq.Result.Eavatar,
                isBan = iq.Result.EisBan,
                create_time = iq.Result.EcreateTime!.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                dept_id = iq.Result.EdeptId,
                duty_id = iq.Result.EdutyId,

            };
        }

        public async Task<Api_Response_Dto> Delete_Admin(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return Get_Result(-1, "参数不能为空");
                }

                var admin = await _org_IOC._employeeLogin_EFCore.QueryAll(e => e.Eid == id).SingleOrDefaultAsync();
                if (admin == null)
                {
                    return Get_Result(-1, "管理员不存在");
                }

                if (admin.Estatus == 1)
                {
                    return Get_Result(-1, "无法删除在职管理员");
                }

                await _org_IOC._employeeLogin_EFCore.DeleteAsync(admin);
                var saveResult = await _org_IOC._employeeLogin_EFCore.SaveChangesAsync();

                return Get_Result(saveResult > 0 ? 1 : -1, saveResult > 0 ? "删除成功" : "删除失败");
            }
            catch(Exception ex)
            {
                return Get_Result(-1, $"删除管理员时发生错误:{ex.Message}");    
            }

        }

        public async Task<Api_Response_Dto> Get_All_Admins()
        {   
            try
            {
                if (_org_IOC == null)
                {
                    return Get_Result(-1, "Org_IOC未注入", null); // 显式传递null
                }
                if (_org_IOC._employeeLogin_EFCore == null)
                    return Get_Result(-1, "服务未初始化", null);

                // 查询全部管理员数据
                var allAdmins = await _org_IOC._employeeLogin_EFCore.QueryAll().ToListAsync();

                // 转换为DTO（数据已正确处理）
                var adminDtos = allAdmins.Select(admin => new Employee_Response_Dto
                {
                    id = admin.Eid,
                    name = admin.Ename,
                    nick = admin.Enick,
                    account = admin.Eaccount,
                    avatar = admin.Eavatar,
                    isBan = admin.EisBan,
                    create_time = admin.EcreateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "",
                    dept_id = admin.EdeptId,
                    duty_id = admin.EdutyId,
                    gender = admin.Egender,
                    email = admin.Eemail,
                    isActive = admin.EisActive,
                    status = admin.Estatus,
                    entry_date = admin.EentryDate?.ToString("yyyy-MM-dd HH:mm:ss")
                }).ToList();

                // 关键修复：将adminDtos传入响应的data字段
                return Get_Result(1, "获取成功", adminDtos);
            }
            catch (Exception ex)
            {
                return Get_Result(-1, $"获取管理员列表失败: {ex.Message}", null);
            }
        }

        public async Task<Api_Response_Dto?> Get_Department_List()
        {
            await Task.CompletedTask;
            var all_department = _org_IOC._orgDepartments_EFCore.QueryAll().ToList();

            var all_employee = _org_IOC._employeeLogin_EFCore.QueryAll().ToList();

            var root = all_department.Where(d => d.DparentId == null || d.DparentId == "").ToList();

            List<Dept_Response_Dto> list = new List<Dept_Response_Dto>();
            root.ForEach(d =>
            {
                int totalCount = CalculateTotalEmployeeCount(d.Did, all_department, all_employee);
                list.Add(new Dept_Response_Dto()
                {
                    id = d.Did,
                    name = d.Dname,
                    parent_id = d.DparentId,
                    count = totalCount,
                    icon = d.Dicon,
                    isBan = d.DisBan,
                    explain = d.Ddescription,
                    time = d.DcreateTime!.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    level = d.DsortOrder,
                    children = GetDeptChildren(d.Did, all_department, all_employee)
                });
            });
            return Get_Result(1, "ok",list);
        }

        /// <summary>
        /// 获取部门下员工数量
        /// </summary>
        /// <param name="did"></param>
        /// <param name="all_department"></param>
        /// <param name="all_employee"></param>
        /// <returns></returns>
        private int CalculateTotalEmployeeCount(string did, List<OrgDepartment> all_department, List<OrgEmployee> all_employee)
        {
            int count = all_employee.Count(e => e.EdeptId == did);
            var children = all_department.Where(d => d.DparentId == did).ToList();
            children.ForEach(d =>
            {
                count += CalculateTotalEmployeeCount(d.Did, all_department, all_employee);
            });
            return count;
        }

        /// <summary>
        /// 管理端-获取部门子节点b
        /// </summary>
        /// <param name="did"></param>
        /// <param name="all_department"></param>
        /// <param name="all_employee"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<Dept_Response_Dto>? GetDeptChildren(string did, List<OrgDepartment> all_department, List<OrgEmployee> all_employee)
        {
            List<Dept_Response_Dto> list = new List<Dept_Response_Dto>();
            var children = all_department.Where(d => d.DparentId == did).ToList();
            children.ForEach(d =>
            {
                int totalCount = CalculateTotalEmployeeCount(d.Did, all_department, all_employee);
                list.Add(new Dept_Response_Dto()
                {
                    id = d.Did,
                    name = d.Dname,
                    parent_id = d.DparentId,
                    count = totalCount,
                    icon = d.Dicon,
                    isBan = d.DisBan,
                    explain = d.Ddescription,
                    time = d.DcreateTime!.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    level = d.DsortOrder,
                    children = GetDeptChildren(d.Did, all_department, all_employee)
                });
            });
            return list;
        }

        /// <summary>
        /// 获取岗位列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Api_Response_Dto> Get_Duty_List(Get_Duty_List_Request_Dto dto)
        {
            dto.keyword = dto.keyword ?? "";
            dto.keyword_time = dto.keyword_time ?? new List<string>();
            var employee = _org_IOC._employeeLogin_EFCore.QueryAll();
            var position = await _org_IOC._orgDutys_EFCore.QueryAll(
                out int total,
                dto.page,
                dto.limit,
                true,
                o => o.Dlevel,
                d => (string.IsNullOrEmpty(dto.keyword) ||
                d.Dname.Contains(dto.keyword) || d.Ddescription!.Contains(dto.keyword)) 
                && (dto.status == -1 || (dto.status == 0 || d.DisBan == 1) ||
                (dto.status == 1 || d.DisBan == 1) || (dto.status == 2 && !employee.Any(e => e.EdutyId == d.Did)))
            ).ToListAsync();

            var data = position.Select(d => new Get_Duty_List_Response_Dto()
            {
                id = d.Did,
                name = d.Dname,
                count = _org_IOC._employeeLogin_EFCore.QueryAll(e => e.EdutyId == d.Did).Count(),
                description = d.Ddescription,
                level = d.Dlevel,
                isBan = d.DisBan,
                create_time = d.DcreateTime!.Value.ToString("yyyy-MM-dd HH:mm:ss"),
            }).ToList();

            return Get_Result(1, "ok", new
            {
                list = data,
                total
            });
        }

        /// <summary>
        /// 获取单个部门的职务列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Api_Response_Dto> Get_Single_Dept_Duty(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Get_Result(-1, "参数不能为空");
            }

            var department = await _org_IOC._orgDepartmentDutys_EFCore.QueryAll(d => d.DddeptId == id).Select(d => d.DddutyId).ToListAsync();

            var duty_list = await _org_IOC._orgDutys_EFCore.QueryAll(d => department.Contains(d.Did))
    .Select(d => new Get_Duty_List_Response_Dto()
    {
        id = d.Did,
        name = d.Dname,
        count = 0,
        description = d.Ddescription,
        level = d.Dlevel,
        isBan = d.DisBan,
        create_time = d.DcreateTime!.Value.ToString("yyyy-MM-dd HH:mm:ss"),
    }).ToListAsync();
            duty_list.ForEach(d =>
            {
                d.count = _org_IOC._employeeLogin_EFCore.QueryAll(e => e.EdutyId == d.id).Count();
            });
            return Get_Result(1, "ok", duty_list);
        }

        /// <summary>
        /// 禁用员工
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Api_Response_Dto> isBan_Admin(isBan_Admin_Request_Dto dto)
        {
            var dutys = await _org_IOC._employeeLogin_EFCore.QueryAll(d => dto.eid!.Contains(d.Eid)).ToListAsync();
            foreach (var duty in dutys)
            {
                duty.EisBan = dto.status;
            }
            var result = await _org_IOC._employeeLogin_EFCore.SaveChangesAsync();
            return Get_Result(result > 0 ? 1 : -1, result > 0 ? "ok" : "fail");
        }

        public async Task<Api_Response_Dto> Logins(Employee_Login_Request_Dto dto)
        {
            var iq = _org_IOC._employeeLogin_EFCore.QueryAll(d => d.Eaccount == dto.account);
            if (!await iq.AnyAsync())
            {
                return Get_Result(-1, "账号不存在");
            }

            var dt = await iq.SingleAsync();
            var pwd = EncryptUtil.LoginMd5(dto.password!, dt.Esalt!);

            if (dt.Epassword != pwd)
            {
                return Get_Result(-1, "账号或者密码错误");
            }

            if (dt.EisBan == 1)
            {
                return Get_Result(-1, "账号已被禁用");
            }

            // 记录登录日志
            await _org_IOC._sysEmployeeLoginLogs_EFCore.AddAsync(new SysEmployeeLoginLog()
            {
                Llid = Config.GUID2(),
                Lleid = dt.Eid,
                LlcreateTime = DateTime.Now,
                Llip = Config.GetIp(),
                Llaccount = dt.Eaccount,
            });

            // 更新账号激活状态
            if (dt.EisActive == 0)
            {   
                dt.EisActive = 1;
            }

            await _org_IOC._sysEmployeeLoginLogs_EFCore.SaveChangesAsync();


            // ------------------- 生成与Program.cs匹配的JWT Token -------------------
            // 1. 读取Program.cs中使用的JWT配置（保持完全一致）
            var jwtIssuer = _configuration["JWT:issuer"]; // 与Program.cs中的jwtKey一致
            var jwtSecurityKey = _configuration["JWT:SecurityKey"]; // 与Program.cs中的签名密钥一致

            // 校验配置是否存在（避免空引用）
            if (string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtSecurityKey))
            {
                return Get_Result(-1, "JWT配置缺失（issuer或SecurityKey未设置）");
            }

            // 2. 定义Claims（必须包含Program.cs中验证的2个Claim：Name=code，Actor=account）
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dto.code ?? ""),   // 对应Program.cs中读取的ClaimTypes.Name（code）
                new Claim(ClaimTypes.Actor, dt.Eaccount),     // 对应Program.cs中读取的ClaimTypes.Actor（account）
                new Claim(ClaimTypes.NameIdentifier, dt.Eid)  // 可选：添加用户ID，方便后续获取当前用户
            };

            // 3. 生成Token（参数与Program.cs的验证规则完全匹配）
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(2); // 有效期（可根据需求调整）

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,         // 与Program.cs的ValidIssuer一致
                audience: jwtIssuer,       // 与Program.cs的ValidAudience一致
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            // ---------------------------------------------------------------------


            // 返回包含Token的结果（前端需保存Token，后续请求携带在Authorization头中）
            return Get_Result(1, "ok", new { Token = tokenString });
        }

        public async Task<Api_Response_Dto> Revise_Admin(Revise_Admin_Request_Dto dto)
        {
            try
            {
                if (dto == null)
                {
                    return Get_Result(-1, "传入的参数不能为空");
                }

                var employee = await _org_IOC._employeeLogin_EFCore.QueryAll(d => d.Eid == dto.Eid).FirstOrDefaultAsync();
                if(employee == null)
                {
                    return Get_Result(-1, $"员工不存在,  id{dto.Eid}");
                }


            }catch (Exception ex)
            {
                return Get_Result(-1, $"修改管理员信息时发生错误:{ex.Message}");
            }
            return Get_Result(0, "ok");
        }
    }
}
