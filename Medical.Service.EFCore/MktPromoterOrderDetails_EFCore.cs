using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广订单详情服务类
    /// </summary>
    [Provider_,Inject_]
    public class MktPromoterOrderDetails_EFCore:Base_EFCore<MktPromoterOrderDetail>
    {
        public MktPromoterOrderDetails_EFCore(I_Repository<MktPromoterOrderDetail> repository) : base(repository) { }

    }
}
