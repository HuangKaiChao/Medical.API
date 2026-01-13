using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//部门服务实现EFCore
public class OrgDepartments_EFCore:Base_EFCore<OrgDepartment>
{
    public OrgDepartments_EFCore(I_Repository<OrgDepartment> repository) : base(repository)
    {
    }
}