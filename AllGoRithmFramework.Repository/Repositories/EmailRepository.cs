using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;

namespace AllGoRithmFramework.Repository.Repositories
{
    public class EmailRepository : BaseRepository<Email>
    {
        public EmailRepository(BaseContext<Email> baseContext) : base(baseContext)
        {
        }
    }
}