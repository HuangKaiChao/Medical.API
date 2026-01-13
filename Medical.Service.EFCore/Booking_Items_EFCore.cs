using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]
    public class Booking_Items_EFCore : Base_EFCore<SchAppointmentItem>
    {
        public Booking_Items_EFCore(I_Repository<SchAppointmentItem> repository) : base(repository)
        {
        }
    }
}
