using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//角色服务实现EFCore
public class SysRoles_EFCore:Base_EFCore<SysRole>
{
    public SysRoles_EFCore(I_Repository<SysRole> repository) : base(repository)
    {
    }
}