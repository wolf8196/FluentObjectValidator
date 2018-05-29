using System.Linq;
using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.Configurations
{
    public class UserDTOConfiguration_TError : ValidationConfiguration<UserDTO, string>
    {
        public UserDTOConfiguration_TError()
        {
            Property(x => x.UserName)
                .IsRequired(() => "UserName IsRequired")
                .HasMaxLength(10, () => "UserName HasMaxLength");

            Property(x => x.Email)
                .IsRequired(() => "Email IsRequired")
                .MatchesRegex("^[^@]+@[^@]+$", () => "Email MatchesRegex");

            Property(x => x.Password)
                .IsRequired(() => "Password IsRequired")
                .HasMinLength(8, () => "Password HasMinLength", stopValidationOnError: true)
                .HasRule(x => x.Any(c => char.IsUpper(c)), () => "Password HasUpper")
                .HasRule(x => x.Any(c => char.IsLower(c)), () => "Password HasLower")
                .HasRule(x => x.Any(c => char.IsNumber(c)), () => "Password HasNumber");
        }
    }
}