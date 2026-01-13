using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广员与客户关系表
    /// </summary>
    [Provider_,Inject_]
    public class MktCustomerPromoter_EFCore:Base_EFCore<MktCustomerPromoter>
    {
        public MktCustomerPromoter_EFCore(I_Repository<MktCustomerPromoter> repository) : base(repository) { }

    }
}
