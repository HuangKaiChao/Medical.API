using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;
namespace Medical.Service.EFCore
{
    /// <summary>
    /// 佣金提现服务类
    /// </summary>
    [Provider_, Inject_]

    public class FinWithdrawals_EFCore : Base_EFCore<FinWithdrawal>
    {
        public FinWithdrawals_EFCore(I_Repository<FinWithdrawal> repository) : base(repository)
        {
        }
    }
}
