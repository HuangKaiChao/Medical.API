using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 排班/日程服务类
    /// </summary>
    [Provider_,Inject_]
    public class SchSchedules_EFCore:Base_EFCore<SchSchedule>
    {
        public SchSchedules_EFCore(I_Repository<SchSchedule> repository) : base(repository) { }

    }
}
