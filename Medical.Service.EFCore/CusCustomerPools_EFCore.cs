using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    /// <summary>
    /// 客户池服务类
    /// </summary>
    [Provider_,Inject_]
    public class CusCustomerPools_EFCore:Base_EFCore<CusCustomerPool>
    {
        public CusCustomerPools_EFCore(I_Repository<CusCustomerPool> repository):base(repository) { }
    }
}
