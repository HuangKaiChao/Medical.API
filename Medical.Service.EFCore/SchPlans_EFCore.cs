using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
// 排班计划实现EFCore
public class SchPlans_EFCore:Base_EFCore<SchPlan>
{
    public SchPlans_EFCore(I_Repository<SchPlan> repository) : base(repository)
    {
    }
}