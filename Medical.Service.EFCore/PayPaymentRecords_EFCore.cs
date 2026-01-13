using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//支付表记录的实现EFCore
public class PayPaymentRecords_EFCore:Base_EFCore<PayPaymentRecord>
{
    public PayPaymentRecords_EFCore(I_Repository<PayPaymentRecord> repository) : base(repository)
    {
    }
}