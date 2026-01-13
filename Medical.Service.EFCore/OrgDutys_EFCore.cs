using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//岗位服务实现EFCore
public class OrgDutys_EFCore:Base_EFCore<OrgDuty>
{
    public OrgDutys_EFCore(I_Repository<OrgDuty> repository) : base(repository)
    {
    }
}