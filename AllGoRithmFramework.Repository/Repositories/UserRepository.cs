using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;
using System.Linq;

namespace AllGoRithmFramework.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(BaseContext<User> baseContext) : base(baseContext)
        {
        }

        public User GetByCredentials(string userNameEmail, string password)
        {
            return this.dbSet.FirstOrDefault(u => (u.Email.Equals(userNameEmail) || u.UserName.Equals(userNameEmail)) && u.Password.Equals(password));
        }

        public bool NameInUse(string userName)
        {
            return this.dbSet.Any(u => u.UserName.Equals(userName));
        }

        public bool EmailInUse(string email)
        {
            return this.dbSet.Any(u => u.Email.Equals(email));
        }
    }
}
