using System;

namespace FluentObjectValidator.Tests.Functional.DTOs
{
    public class MessageDTO
    {
        public long? SenderId { get; set; }

        public long? ReceiverId { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}