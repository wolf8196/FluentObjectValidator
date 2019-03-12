using System.Linq;
using DemoApps.DTOs;
using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;

namespace ObjectResultValidationApp.Validation.ValidationConfigurations
{
    public class UserDTOConfiguration : ValidationConfiguration<UserDTO, ValidationError>
    {
        public UserDTOConfiguration()
        {
            Property(x => x.UserName)
                .IsRequired(() => new ValidationError("UserName is required"))
                .HasMaxLength(
                    10,
                    () => new ValidationError("UserName is too long"));

            Property(x => x.Email)
                .IsRequired(() => new ValidationError("Email is required"))
                .MatchesRegex(
                    "^[^@]+@[^@]+$",
                    () => new ValidationError("Not valid email"));

            Property(x => x.Password)
                .IsRequired(() => new ValidationError("Password is required"))
                .HasMinLength(
                    8,
                    () => new ValidationError("Password has to be at least 8 characters"),
                    stopValidationOnError: true)
                .HasRule(
                    x => x.Any(c => char.IsUpper(c)),
                    () => new ValidationError("Password has to contain at least 1 uppercase letter"))
                .HasRule(
                    x => x.Any(c => char.IsLower(c)),
                    () => new ValidationError("Password has to contain at least 1 lowercase letter"))
                .HasRule(
                    x => x.Any(c => char.IsNumber(c)),
                    () => new ValidationError("Password has to contain at least 1 digit"));
        }
    }
}