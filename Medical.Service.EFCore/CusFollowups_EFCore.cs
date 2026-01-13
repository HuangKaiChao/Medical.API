using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 客户跟进服务类
    /// </summary>
    [Provider_,Inject_]
    public class CusFollowups_EFCore:Base_EFCore<CusFollowup>
    {
        public CusFollowups_EFCore(I_Repository<CusFollowup> repository):base(repository) { }
    }
}
