using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.Configurations
{
    public class MessageDTOConfiguration : ValidationConfiguration<MessageDTO>
    {
        public MessageDTOConfiguration()
        {
            Property(x => x.SenderId)
                .IsRequired();

            Property(x => x.ReceiverId)
                .IsRequired();

            Property(x => x.Date)
                .IsRequired();

            Property(x => x.Text)
                .IsRequired()
                .HasLengthInRange(1, 10);
        }
    }
}