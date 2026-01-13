using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//套餐产品项关联表服务实现EFCore
public class ProPackageProducts_EFCore:Base_EFCore<ProPackageProduct>
{
    public ProPackageProducts_EFCore(I_Repository<ProPackageProduct> repository) : base(repository)
    {
    }
}