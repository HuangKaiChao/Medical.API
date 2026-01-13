using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]
    public class Members_EFCore : Base_EFCore<CusMember>
    {
        public Members_EFCore(I_Repository<CusMember> repository) : base(repository)
        {
        }
    }
}
