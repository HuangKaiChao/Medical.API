using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 预约项目服务类
    /// </summary>
    [Provider_,Inject_]
    public class SchAppointmentItems_EFCore:Base_EFCore<SchAppointmentItem>
    {
        public SchAppointmentItems_EFCore(I_Repository<SchAppointmentItem> repository) : base(repository) { }

    }
}
