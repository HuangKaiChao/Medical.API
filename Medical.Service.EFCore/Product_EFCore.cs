using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    public class Product_EFCore:Base_EFCore<ProProduct>
    {
        public Product_EFCore(I_Repository<ProProduct> repository) : base(repository) { }

    }
}
