using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//产品订单详情实现EFCore
public class ProOrdersDetails_EFCore:Base_EFCore<ProOrderDetail>
{
    public ProOrdersDetails_EFCore(I_Repository<ProOrderDetail> repository) : base(repository)
    {
    }
}