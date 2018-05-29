using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.Configurations
{
    public class AdvertDTOConfiguration_TError : ValidationConfiguration<AdvertDTO, string>
    {
        public AdvertDTOConfiguration_TError()
        {
            Property(x => x.Title)
                .IsRequired(() => "Title IsRequired")
                .HasMinLength(3, () => "Title HasMinLength")
                .HasMaxLength(10, () => "Title HasMaxLength");

            Property(x => x.Price)
                .IsRequired(() => "Price IsRequired");

            Property(x => x.Description)
                .IsRequired(() => "Description IsRequired")
                .HasMaxLength(10, () => "Description HasMaxLength");

            Property(x => x.AddressIds)
                .IsRequired(() => "AddressIds IsRequired")
                .HasRule(x => x.Length >= 1, () => "AddressIds HasRule");
        }
    }
}