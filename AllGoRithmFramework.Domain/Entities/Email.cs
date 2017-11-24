using System;
using AllGoRithmFramework.Domain.Enums;

namespace AllGoRithmFramework.Domain.Entities
{
    public class Email : BaseEntity
    {
        public int EmailId { get; private set; }

        public string Recipient { get; private set; }

        public string Subject { get; private set; }

        public string Message { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime SendDate { get; private set; }

        public EmailState EmailState { get; private set; }

        private Email()
        {
        }

        public Email(string recipient, string subject, string message)
        {
            this.Recipient = recipient;
            this.Subject = subject;
            this.Message = message;
            this.CreationDate = DateTime.Now;
            this.EmailState = EmailState.Waiting;
        }

        public Email UpdateToSent()
        {
            this.SendDate = DateTime.Now;
            this.EmailState = EmailState.Sent;

            return this;
        }

        public Email UpdateToError(string errorMessage)
        {
            this.Message = errorMessage + " - " + this.Message;
            this.EmailState = EmailState.Error;

            return this;
        }
    }
}