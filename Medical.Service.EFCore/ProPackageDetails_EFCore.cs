using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//套餐服务项关联表服务实现EFCore
public class ProPackageDetails_EFCore:Base_EFCore<ProPackageDetail>
{
    public ProPackageDetails_EFCore(I_Repository<ProPackageDetail> repository) : base(repository)
    {
    }
}