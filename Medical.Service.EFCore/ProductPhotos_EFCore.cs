using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    //产品图片服务实现EFCore
    public class ProductPhotos_EFCore:Base_EFCore<ProProductPhoto>
    {
        public ProductPhotos_EFCore(I_Repository<ProProductPhoto> repository) : base(repository) { }

    }
}
