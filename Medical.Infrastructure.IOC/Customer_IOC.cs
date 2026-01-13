using Medical.Infrastructure.Attr;
using Medical.Service.EFCore;

namespace Medical.Infrastructure.IOC
{
    [Provider_,Inject_]
    public class Customer_IOC
    {
        public readonly Customers_EFCore _customers_EFCore;
        public readonly CusFollowups_EFCore _cusFollowups_EFCore;

        public Customer_IOC(Customers_EFCore customers_EFCore,
            CusFollowups_EFCore cusFollowups_EFCore)
        {
            _customers_EFCore = customers_EFCore;
            _cusFollowups_EFCore = cusFollowups_EFCore;
        }
    }
}
