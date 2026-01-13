using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//部门岗位服务实现EFCore
public class OrgDepartmentDutys_EFCore:Base_EFCore<OrgDepartmentDuty>
{
    public OrgDepartmentDutys_EFCore(I_Repository<OrgDepartmentDuty> repository) : base(repository)
    {
    }
}