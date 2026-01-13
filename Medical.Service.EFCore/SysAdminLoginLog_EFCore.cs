using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]
    public class SysAdminLoginLog_EFCore : Base_EFCore<SysAdminLoginLog>
    {
        public SysAdminLoginLog_EFCore(I_Repository<SysAdminLoginLog> repository) : base(repository)
        {
        }
    }
}
