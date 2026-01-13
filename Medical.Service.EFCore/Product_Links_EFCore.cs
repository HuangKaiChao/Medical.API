using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    public class Product_Links_EFCore : Base_EFCore<MktPromoterLink>
    {
        public Product_Links_EFCore(I_Repository<MktPromoterLink> repository) : base(repository) { }

    }
}
