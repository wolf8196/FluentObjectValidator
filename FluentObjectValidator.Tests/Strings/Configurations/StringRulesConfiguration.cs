using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Strings.DTOs;

namespace FluentObjectValidator.Tests.Strings.Configurations
{
    public class StringRulesConfiguration : ValidationConfiguration<StringDTO>
    {
        public StringRulesConfiguration(int ruleSetId)
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
                .IsRequired(true)
                .HasMaxLength(10);
        }

        public void AddRuleSet2()
        {
            Property(x => x.StringProp)
                .IsRequired()
                .HasMinLength(5)
                .HasMaxLength(10)
                .HasRule(x => x.Contains("test"));
        }

        public void AddRuleSet3()
        {
            Property(x => x.StringProp)
                .IsRequired()
                .HasLengthInRange(5, 10)
                .MatchesRegex("test");
        }
    }
}