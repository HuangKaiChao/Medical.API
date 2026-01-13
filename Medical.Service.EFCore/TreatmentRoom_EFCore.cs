using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]
    public class TreatmentRoom_EFCore : Base_EFCore<SchTherapyRoom>
    {
        public TreatmentRoom_EFCore(I_Repository<SchTherapyRoom> repository) : base(repository)
        {
        }
    }
}
