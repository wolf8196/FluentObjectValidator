using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.Configurations
{
    public class AdvertDTOConfiguration : ValidationConfiguration<AdvertDTO>
    {
        public AdvertDTOConfiguration()
        {
            Property(x => x.Title)
                .IsRequired()
                .HasMinLength(3)
                .HasMaxLength(10);

            Property(x => x.Price)
                .IsRequired();

            Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(10);

            Property(x => x.AddressIds)
                .IsRequired()
                .HasRule(x => x.Length >= 1);
        }
    }
}