using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using System.Linq;

namespace AllGoRithmFramework.Repository.Repositories
{
    public class SystemParameterRepository : BaseRepository<SystemParameter>
    {
        public SystemParameterRepository(BaseContext<SystemParameter> baseContext) : base(baseContext)
        {
        }

        public SystemParameter GetByName(string name)
        {
            return this.dbSet.FirstOrDefault(s => s.Name.Equals(name));
        }
    }
}
