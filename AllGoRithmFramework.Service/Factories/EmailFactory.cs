using AllGoRithmFramework.Domain.DataObjects;
using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Domain.Enums;

namespace AllGoRithmFramework.Service.Factories
{
    public class EmailFactory : IBaseFactory<Email, EmailDto>
    {
        public Email Create(EmailDto source)
        {
            return new Email(source.Recipient, source.Subject, source.Message);
        }
    }
}