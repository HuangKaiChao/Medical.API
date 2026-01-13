using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]

    public class ArtCommentLikes_EFCore : Base_EFCore<ArtCommentLike>
    {
        public ArtCommentLikes_EFCore(I_Repository<ArtCommentLike> repository) : base(repository)
        {
        }
    }
}
