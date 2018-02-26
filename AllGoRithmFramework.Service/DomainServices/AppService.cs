using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;

namespace AllGoRithmFramework.Service.DomainServices
{
    public class AppService : BaseDomainService<App>
    {
        public AppService(BaseContext<App> dbContext) : base(dbContext)
        {
        }
    }
}