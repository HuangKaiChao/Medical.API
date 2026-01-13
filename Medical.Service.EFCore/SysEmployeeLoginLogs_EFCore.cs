using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//员工登录日志服务实现EFCore
public class SysEmployeeLoginLogs_EFCore:Base_EFCore<SysEmployeeLoginLog>
{
    public SysEmployeeLoginLogs_EFCore(I_Repository<SysEmployeeLoginLog> repository) : base(repository)
    {
    }
}