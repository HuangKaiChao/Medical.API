using Medical.Infrastructure.Attr;
using Medical.Service.EFCore;

namespace Medical.Infrastructure.IOC
{
    /// <summary>
    /// 模块
    /// </summary>
    [Provider_, Inject_]
    public class Module_IOC
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly SysModule_EFCore _sysModule_EFCore;

        public Module_IOC(SysModule_EFCore sysModule_EFCore)
        {
            _sysModule_EFCore = sysModule_EFCore;
        }
    }
}
