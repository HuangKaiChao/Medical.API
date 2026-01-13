using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 推广订单拒绝服务层
    /// </summary>
    [Provider_,Inject_]
    public class MktOrderRejections_EFCore:Base_EFCore<MktOrderRejection>
    {
        public MktOrderRejections_EFCore(I_Repository<MktOrderRejection> repository) : base(repository) { }

    }
}
