using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//产品订单实现EFCore
public class ProOrders_EFCore:Base_EFCore<ProOrder>
{
    public ProOrders_EFCore(I_Repository<ProOrder> repository) : base(repository)
    {
    }
}