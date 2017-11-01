using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AllGoRithmFramework.Repository.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly BaseContext<T> baseContext;
        protected DbSet<T> dbSet;

        public BaseRepository(BaseContext<T> baseContext)
        {
            this.baseContext = baseContext;
            this.dbSet = baseContext.DbSet;
        }

        public T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public IList<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);

            this.baseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            this.Delete(this.GetById(id));
        }

        public void Insert(T entity)
        {
            this.dbSet.Add(entity);

            this.baseContext.SaveChanges();
        }

        public void Update(T enitity)
        {
            this.baseContext.SaveChanges();
        }
    }
}
