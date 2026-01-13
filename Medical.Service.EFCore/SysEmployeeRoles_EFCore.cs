using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//员工角色服务实现EFCore
public class SysEmployeeRoles_EFCore:Base_EFCore<SysEmployeeRole>
{
    public SysEmployeeRoles_EFCore(I_Repository<SysEmployeeRole> repository) : base(repository)
    {
    }
}