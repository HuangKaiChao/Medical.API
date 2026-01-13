using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广佣金规则服务类
    /// </summary>
    [Provider_,Inject_]
    public class MktCommissionRules_EFCore:Base_EFCore<MktCommissionRule>
    {
        public MktCommissionRules_EFCore(I_Repository<MktCommissionRule> repository) : base(repository) { }

    }
}
