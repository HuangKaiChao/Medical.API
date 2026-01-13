using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]
    public class RoomAppointments_EFCore : Base_EFCore<SchRoomAppointment>
    {
        public RoomAppointments_EFCore(I_Repository<SchRoomAppointment> repository) : base(repository)
        {
        }
    }
}
