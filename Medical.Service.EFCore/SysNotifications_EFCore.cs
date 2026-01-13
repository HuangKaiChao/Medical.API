using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
// 系统通知服务实现EFCore
public class SysNotifications_EFCore:Base_EFCore<SysNotification>
{
    public SysNotifications_EFCore(I_Repository<SysNotification> repository) : base(repository)
    {
    }
}