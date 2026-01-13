using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]

    public class ArtLikes_EFCore : Base_EFCore<ArtLike>
    {
        public ArtLikes_EFCore(I_Repository<ArtLike> repository) : base(repository)
        {
        }
    }
}
