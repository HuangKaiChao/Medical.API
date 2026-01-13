using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    public class Customers_EFCore:Base_EFCore<CusCustomer>
    {
        public Customers_EFCore(I_Repository<CusCustomer> repository):base(repository) { }
    }
}
