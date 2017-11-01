namespace AllGoRithmFramework.Domain.Entities
{
    public class User : BaseEntity
    {
        public int UserId { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public User(string userName, string email, string password)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }
    }
}
