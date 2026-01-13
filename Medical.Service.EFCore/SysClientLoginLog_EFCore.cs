using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    public class SysClientLoginLog_EFCore : Base_EFCore<SysClientLoginLog>
    {
        public SysClientLoginLog_EFCore(I_Repository<SysClientLoginLog> repository):base(repository) { }
    }
}
