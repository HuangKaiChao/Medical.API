using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore;
[Provider_,Inject_]
//系统字典服务实现EFCore
public class SysDictionarys_EFCore:Base_EFCore<SysDictionary>
{
    public SysDictionarys_EFCore(I_Repository<SysDictionary> repository) : base(repository)
    {
    }
}