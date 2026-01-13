using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]

    public class ArtComments_EFCore : Base_EFCore<ArtComment>
    {
        public ArtComments_EFCore(I_Repository<ArtComment> repository) : base(repository)
        {
        }
    }
}
