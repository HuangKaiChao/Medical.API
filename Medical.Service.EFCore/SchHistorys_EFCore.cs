using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//排班历史记录实现EFCore
public class SchHistorys_EFCore :Base_EFCore<SchHistory>
{
    public SchHistorys_EFCore(I_Repository<SchHistory> repository) : base(repository)
    {
    }
}