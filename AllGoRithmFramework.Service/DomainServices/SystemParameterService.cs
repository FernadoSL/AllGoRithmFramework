using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using AllGoRithmFramework.Repository.Repositories;
using System;

namespace AllGoRithmFramework.Service.DomainServices
{
    public class SystemParameterService : BaseDomainService<SystemParameter>
    {
        protected SystemParameterRepository SystemParameterRepository { get; set; }

        public SystemParameterService(BaseContext<SystemParameter> dbContext) : base(dbContext)
        {
            this.SystemParameterRepository = new SystemParameterRepository(dbContext);
        }

        public SystemParameter GetByName(string name)
        {
            return this.SystemParameterRepository.GetByName(name);
        }

        public T GetValue<T>(string name) where T : IConvertible
        {
            SystemParameter systemParameter = this.GetByName(name);
            Type returnType = typeof(T);

            var value = Convert.ChangeType(systemParameter.Value, returnType);
            return (T)value;
        }
    }
}
