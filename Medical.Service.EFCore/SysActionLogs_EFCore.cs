using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//行为日志服务实现EFCore
public class SysActionLogs_EFCore:Base_EFCore<SysActionLog>
{
    public SysActionLogs_EFCore(I_Repository<SysActionLog> repository) : base(repository)
    {
    }
}