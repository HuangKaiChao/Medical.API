using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_,Inject_]
    //产品库存服务实现EFCore
    public class ProductInventorys_EFCore:Base_EFCore<ProProductInventory>
    {
        public ProductInventorys_EFCore(I_Repository<ProProductInventory> repository) : base(repository) { }

    }
}
