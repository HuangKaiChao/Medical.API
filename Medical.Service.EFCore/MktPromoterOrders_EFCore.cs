using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广订单服务类
    /// </summary>
    [Provider_,Inject_]
    public class MktPromoterOrders_EFCore:Base_EFCore<MktPromoterOrder>
    {
        public MktPromoterOrders_EFCore(I_Repository<MktPromoterOrder> repository) : base(repository) { }

    }
}
