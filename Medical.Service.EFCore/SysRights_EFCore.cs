using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//权限/菜单服务实现EFCore
public class SysRights_EFCore:Base_EFCore<SysRight>
{
    public SysRights_EFCore(I_Repository<SysRight> repository) : base(repository)
    {
    }
}