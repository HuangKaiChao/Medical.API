using Medical.Infrastructure.Attr;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Repository.Interface;

namespace Medical.Service.EFCore
{
    [Provider_, Inject_]

    public class ArtViews_EFCore : Base_EFCore<ArtView>
    {
        public ArtViews_EFCore(I_Repository<ArtView> repository) : base(repository)
        {
        }
    }
}
