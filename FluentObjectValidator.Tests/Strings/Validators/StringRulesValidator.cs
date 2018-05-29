using FluentObjectValidator.Tests.Strings.Configurations;

namespace FluentObjectValidator.Tests.Strings.Validators
{
    public class StringRulesValidator : Validator
    {
        public StringRulesValidator(int ruleSetNumber)
        {
            switch (ruleSetNumber)
            {
                case 1:
                    AddConfiguration(new StringRulesConfiguration(1));
                    break;

                case 2:
                    AddConfiguration(new StringRulesConfiguration(2));
                    break;

                case 3:
                    AddConfiguration(new StringRulesConfiguration(3));
                    break;

                default:
                    break;
            }
        }
    }
}