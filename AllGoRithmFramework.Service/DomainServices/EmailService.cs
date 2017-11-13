using System;
using System.Net.Mail;
using AllGoRithmFramework.Domain.Entities;
using AllGoRithmFramework.Repository.Contexts;

namespace AllGoRithmFramework.Service.DomainServices
{
    public class EmailService : BaseDomainService<Email>
    {
        public EmailService(BaseContext<Email> dbContext) : base(dbContext)
        {
        }

        public void Send(Email email)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    Subject = email.Subject,
                    Body = email.Message
                };

                mail.To.Add(new MailAddress(email.Recipient));

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mail);

                this.Update(email.UpdateToSent());
            }
            catch(Exception ex)
            {
                this.Update(email.UpdateToError(ex.Message));
            }
        }
    }
}