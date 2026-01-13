using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]
    public class SysModule_EFCore : Base_EFCore<SysModule>
    {
        public SysModule_EFCore(I_Repository<SysModule> repository) : base(repository)
        {
        }
    }
}
