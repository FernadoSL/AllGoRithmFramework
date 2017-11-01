using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using AllGoRithmFramework.Repository.Repositories;

namespace AllGoRithmFramework.Service.DomainServices
{
    public class UserService : BaseDomainService<User>
    {
        protected UserRepository UserRepository { get; set; }

        public UserService(BaseContext<User> dbContext) : base(dbContext)
        {
            this.UserRepository = new UserRepository(dbContext);
        }

        public User GetByCredentials(string userNameEmail, string password)
        {
            return this.UserRepository.GetByCredentials(userNameEmail, password);
        }
        
        public bool NameInUse(string userName)
        {
            return this.UserRepository.NameInUse(userName);
        }

        public bool EmailInUse(string email)
        {
            return this.UserRepository.EmailInUse(email);
        }
    }
}
