using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//员工登录服务实现EFCore
public class EmployeeLogin_EFCore:Base_EFCore<OrgEmployee>
{
    public EmployeeLogin_EFCore(I_Repository<OrgEmployee> repository) : base(repository)
    {
    }
}