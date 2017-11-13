using System;

namespace AllGoRithmFramework.Domain.DataObjects
{
    public class EmailDto : BaseDto
    {
        public string Recipient { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime SendDate { get; set; }

        public int EmailState { get; set; }
    }
}