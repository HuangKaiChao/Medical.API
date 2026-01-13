using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;
namespace Medical.Service.EFCore
{
    /// <summary>
    /// 佣金结算
    /// </summary>
    [Provider_, Inject_]

    public class FinCommissions_EFCore : Base_EFCore<FinCommission>
    {
        public FinCommissions_EFCore(I_Repository<FinCommission> repository) : base(repository)
        {
        }
    }
}
