using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]
    public class Appointments_EFCore : Base_EFCore<SchAppointment>
    {
        public Appointments_EFCore(I_Repository<SchAppointment> repository) : base(repository)
        {
        }
    }
}
