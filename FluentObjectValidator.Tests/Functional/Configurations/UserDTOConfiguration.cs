using System.Linq;
using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.Configurations
{
    public class UserDTOConfiguration : ValidationConfiguration<UserDTO>
    {
        public UserDTOConfiguration()
        {
            Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(10);

            Property(x => x.Email)
                .IsRequired()
                .MatchesRegex("^[^@]+@[^@]+$");

            Property(x => x.Password)
                .IsRequired()
                .HasMinLength(8)
                .HasRule(x => x.Any(c => char.IsUpper(c)))
                .HasRule(x => x.Any(c => char.IsLower(c)))
                .HasRule(x => x.Any(c => char.IsNumber(c)));
        }
    }
}