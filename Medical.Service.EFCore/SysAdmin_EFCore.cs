using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    public class SysAdmin_EFCore:Base_EFCore<SysAdmin>
    {
        public SysAdmin_EFCore(I_Repository<SysAdmin> repository) : base(repository)
        {
        }

    }
}
