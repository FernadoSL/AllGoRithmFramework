using AllGoRithmFramework.Domain.DataObjects;
using AllGoRithmFramework.Domain.Entities;

namespace AllGoRithmFramework.Service.Factories
{
    public class UserFactory : IBaseFactory<User, UserDto>
    {
        public User Create(UserDto source)
        {
            return new User(source.UserName, source.Email, source.Password);
        }
    }
}
