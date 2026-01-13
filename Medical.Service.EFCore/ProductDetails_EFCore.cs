using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    //产品详情实现EFCore
    public class ProductDetails_EFCore:Base_EFCore<ProProductDetail>
    {
        public ProductDetails_EFCore(I_Repository<ProProductDetail> repository) : base(repository) { }

    }
}
