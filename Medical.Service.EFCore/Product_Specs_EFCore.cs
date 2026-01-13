using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    public class Product_Specs_EFCore : Base_EFCore<ProProductSpec>
    {
        public Product_Specs_EFCore(I_Repository<ProProductSpec> repository) : base(repository) { }

    }
}
