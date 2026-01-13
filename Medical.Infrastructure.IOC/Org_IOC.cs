using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Service.EFCore;

namespace Medical.Infrastructure.IOC
{
    [Provider_,Inject_]
    public class Org_IOC
    {
        /// <summary>
        /// 员工登录
        /// </summary>
        public readonly EmployeeLogin_EFCore _employeeLogin_EFCore;
        /// <summary>
        /// 员工登录日志
        /// </summary>
        public readonly SysEmployeeLoginLogs_EFCore _sysEmployeeLoginLogs_EFCore;

        /// <summary>
        /// 部门岗位
        /// </summary>
        public readonly OrgDepartmentDutys_EFCore _orgDepartmentDutys_EFCore;

        /// <summary>
        /// 部门
        /// </summary>
        public readonly OrgDepartments_EFCore _orgDepartments_EFCore;
        /// <summary>
        ///职务
        /// </summary>
        public readonly OrgDutys_EFCore _orgDutys_EFCore;

        public Org_IOC(EmployeeLogin_EFCore employeeLogin_EFCore,
            SysEmployeeLoginLogs_EFCore sysEmployeeLoginLogs_EFCore,
            OrgDepartmentDutys_EFCore orgDepartmentDutys_EFCore,
            OrgDepartments_EFCore orgDepartments_EFCore,
            OrgDutys_EFCore orgDutys_EFCore
            )
        {
            _employeeLogin_EFCore = employeeLogin_EFCore;
            _sysEmployeeLoginLogs_EFCore = sysEmployeeLoginLogs_EFCore;
            _orgDepartmentDutys_EFCore = orgDepartmentDutys_EFCore;
            _orgDepartments_EFCore = orgDepartments_EFCore;
            _orgDutys_EFCore = orgDutys_EFCore;
        }

    }
}
