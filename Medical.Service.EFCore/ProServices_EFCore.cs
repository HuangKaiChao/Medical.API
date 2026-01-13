using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//服务服务实现EFCore
public class ProServices_EFCore:Base_EFCore<ProService>
{
    public ProServices_EFCore(I_Repository<ProService> repository) : base(repository)
    {
    }
}