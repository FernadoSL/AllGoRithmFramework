using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace AllGoRithmFramework.Repository.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private readonly BaseContext<T> baseContext;

        public BaseRepository(BaseContext<T> baseContext)
        {
            this.baseContext = baseContext;
        }

        public T GetById(int id)
        {
            return this.baseContext.DbSet.Find(id);
        }

        public IList<T> GetAll()
        {
            return this.baseContext.DbSet.ToList();
        }

        public void Delete(T entity)
        {
            this.baseContext.DbSet.Remove(entity);

            this.baseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            this.Delete(this.GetById(id));
        }

        public void Insert(T entity)
        {
            this.baseContext.DbSet.Add(entity);

            this.baseContext.SaveChanges();
        }

        public void Update(T enitity)
        {
            this.baseContext.SaveChanges();
        }

    }
}
