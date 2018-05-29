using FluentObjectValidator.Tests.Strings.DTOs;

namespace FluentObjectValidator.Tests.Strings.TestDataGenerators
{
    public class StringTestDataGenerator : BaseTestDataGenerator<StringDTO>
    {
        protected StringDTO CreateObject(string prop)
        {
            return new StringDTO
            {
                StringProp = prop
            };
        }
    }
}