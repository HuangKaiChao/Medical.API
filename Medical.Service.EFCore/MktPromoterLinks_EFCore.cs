using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广链接服务类
    /// </summary>
    [Provider_,Inject_]
    public class MktPromoterLinks_EFCore:Base_EFCore<MktPromoterLink>
    {
        public MktPromoterLinks_EFCore(I_Repository<MktPromoterLink> repository) : base(repository) { }

    }
}
