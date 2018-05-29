using FluentObjectValidator.Tests.Strings.Configurations;

namespace FluentObjectValidator.Tests.Strings.Validators
{
    public class StringRulesValidator_TError : Validator<string>
    {
        public StringRulesValidator_TError(int ruleSetNumber)
        {
            switch (ruleSetNumber)
            {
                case 1:
                    AddConfiguration(new StringRulesConfiguration_TError(1));
                    break;

                case 2:
                    AddConfiguration(new StringRulesConfiguration_TError(2));
                    break;

                case 3:
                    AddConfiguration(new StringRulesConfiguration_TError(3));
                    break;

                default:
                    break;
            }
        }
    }
}