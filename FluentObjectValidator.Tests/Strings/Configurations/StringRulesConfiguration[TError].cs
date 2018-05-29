using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Strings.DTOs;

namespace FluentObjectValidator.Tests.Strings.Configurations
{
    public class StringRulesConfiguration_TError : ValidationConfiguration<StringDTO, string>
    {
        public StringRulesConfiguration_TError(int ruleSetId)
        {
            switch (ruleSetId)
            {
                case 1:
                    AddRuleSet1();
                    break;

                case 2:
                    AddRuleSet2();
                    break;

                case 3:
                    AddRuleSet3();
                    break;

                default:
                    break;
            }
        }

        public void AddRuleSet1()
        {
            Property(x => x.StringProp)
                .IsRequired(true, () => "IsRequired")
                .HasMaxLength(10, () => "HasMaxLength");
        }

        public void AddRuleSet2()
        {
            Property(x => x.StringProp)
                .IsRequired(() => "IsRequired")
                .HasMinLength(5, () => "HasMinLength")
                .HasMaxLength(10, () => "HasMaxLength")
                .HasRule(x => x.Contains("test"), () => "Contains");
        }

        public void AddRuleSet3()
        {
            Property(x => x.StringProp)
                .IsRequired(() => "IsRequired")
                .HasLengthInRange(5, 10, () => "HasLengthInRange")
                .MatchesRegex("test", () => "MatchesRegex");
        }
    }
}