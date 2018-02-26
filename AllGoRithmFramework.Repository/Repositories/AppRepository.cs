using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using System.Linq;

namespace AllGoRithmFramework.Repository.Repositories
{
    public class AppRepository : BaseRepository<App>
    {
        public AppRepository(BaseContext<App> baseContext) : base(baseContext)
        {
        }
    }
}