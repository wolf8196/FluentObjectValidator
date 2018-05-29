using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.Configurations
{
    public class MessageDTOConfiguration_TError : ValidationConfiguration<MessageDTO, string>
    {
        public MessageDTOConfiguration_TError()
        {
            Property(x => x.SenderId)
                .IsRequired(() => "SenderId IsRequired");

            Property(x => x.ReceiverId)
                .IsRequired(() => "ReceiverId IsRequired");

            Property(x => x.Date)
                .IsRequired(() => "Date IsRequired");

            Property(x => x.Text)
                .IsRequired(() => "Text IsRequired")
                .HasLengthInRange(1, 10, () => "Text HasLengthInRange");
        }
    }
}