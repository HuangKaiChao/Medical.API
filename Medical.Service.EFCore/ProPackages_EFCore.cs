using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//服务套餐服务实现EFCore
public class ProPackages_EFCore:Base_EFCore<ProPackage>
{
    public ProPackages_EFCore(I_Repository<ProPackage> repository) : base(repository)
    {
    }
}