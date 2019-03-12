using DemoApps.DTOs;
using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;

namespace ObjectResultValidationApp.Validation.ValidationConfigurations
{
    public class ProductDTOConfiguration : ValidationConfiguration<ProductDTO, ValidationError>
    {
        public ProductDTOConfiguration()
        {
            Property(x => x.Title)
                .IsRequired(() => new ValidationError("Title is required"))
                .HasMaxLength(10, () => new ValidationError("Title is too long"));

            Property(x => x.CategoryId)
                .IsRequired(() => new ValidationError("CategoryId is required"));

            Property(x => x.Price)
                .IsRequired(() => new ValidationError("Price is required"));

            Property(x => x.Description)
                .IsRequired(() => new ValidationError("Description is required"))
                .HasMaxLength(50, () => new ValidationError("Description is too long"));
        }
    }
}