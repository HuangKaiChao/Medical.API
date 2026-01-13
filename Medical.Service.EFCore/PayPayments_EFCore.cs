using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//支付表的实现EFCore
public class PayPayments_EFCore:Base_EFCore<PayPayment>
{
    public PayPayments_EFCore(I_Repository<PayPayment> repository) : base(repository)
    {
    }
}