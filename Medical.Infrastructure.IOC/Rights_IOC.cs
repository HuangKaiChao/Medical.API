using Medical.Infrastructure.Attr;
using Medical.Service.EFCore;

namespace Medical.Infrastructure.IOC
{
    [Provider_,Inject_]
    public class Rights_IOC
    {
        public readonly SysEmployeeRoles_EFCore _sysEmployeeRoles_EFCore;

        public Rights_IOC(SysEmployeeRoles_EFCore sysEmployeeRoles_EFCore)
        {
            _sysEmployeeRoles_EFCore = sysEmployeeRoles_EFCore;
        }
    }
}
