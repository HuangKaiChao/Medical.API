using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//错误日志服务实现EFCore
public class SysErrorLogs_EFCore:Base_EFCore<SysErrorLog>
{
    public SysErrorLogs_EFCore(I_Repository<SysErrorLog> repository) : base(repository)
    {
    }
}