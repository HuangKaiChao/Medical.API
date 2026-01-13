using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广商服务类
    /// </summary>
    [Provider_,Inject_]
    public class MktPromoters_EFCore:Base_EFCore<MktPromoter>
    {
        public MktPromoters_EFCore(I_Repository<MktPromoter> repository) : base(repository) { }

    }
}
