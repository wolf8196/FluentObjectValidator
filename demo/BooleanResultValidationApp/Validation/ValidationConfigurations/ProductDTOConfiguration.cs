using DemoApps.DTOs;
using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;

namespace BooleanResultValidationApp.Validation.ValidationConfigurations
{
    public class ProductDTOConfiguration : ValidationConfiguration<ProductDTO>
    {
        public ProductDTOConfiguration()
        {
            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(10);

            Property(x => x.CategoryId)
                .IsRequired();

            Property(x => x.Price)
                .IsRequired();

            Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}