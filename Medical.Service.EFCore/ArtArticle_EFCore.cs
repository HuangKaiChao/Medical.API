using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]

    public class ArtArticle_EFCore : Base_EFCore<ArtArticle>
    {
        public ArtArticle_EFCore(I_Repository<ArtArticle> repository) : base(repository)
        {
        }
    }
}
