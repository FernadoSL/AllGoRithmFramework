using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using AllGoRithmFramework.Repository.Repositories;
using System.Collections.Generic;

namespace AllGoRithmFramework.Service.DomainServices
{
    public class BaseDomainService<T> where T : BaseEntity
    {
        protected BaseRepository<T> Repository { get; set; }

        public BaseDomainService(BaseContext<T> dbContext)
        {
            this.Repository = new BaseRepository<T>(dbContext);
        }

        public T GetById(int id)
        {
            return this.Repository.GetById(id);
        }

        public IList<T> GetAll()
        {
            return this.Repository.GetAll();
        }

        public void Delete(T entity)
        {
            this.Repository.Delete(entity);
        }

        public void Delete(int id)
        {
            this.Delete(this.GetById(id));
        }

        public void Insert(T entity)
        {
            this.Repository.Insert(entity);
        }

        public void Update(T entity)
        {
            this.Repository.Update(entity);
        }
    }
}
