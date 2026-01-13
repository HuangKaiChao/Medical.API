using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    public class Promoter_EFCore : Base_EFCore<MktPromoter>
    {
        public Promoter_EFCore(I_Repository<MktPromoter> repository):base(repository) { }
    }
}
