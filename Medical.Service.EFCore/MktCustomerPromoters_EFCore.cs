using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广客户客户关系服务类
    /// </summary>
    [Provider_,Inject_]
    public class MktCustomerPromoters_EFCore:Base_EFCore<MktCustomerPromoter>
    {
        public MktCustomerPromoters_EFCore(I_Repository<MktCustomerPromoter> repository) : base(repository) { }

    }
}
