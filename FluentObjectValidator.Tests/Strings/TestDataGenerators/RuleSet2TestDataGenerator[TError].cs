using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Strings.TestDataGenerators
{
    public class RuleSet2TestDataGenerator_TError : StringTestDataGenerator
    {
        public RuleSet2TestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(null), "IsRequired"),
                Transform(CreateObject(""), "IsRequired"),
                Transform(CreateObject("      "), "IsRequired"),
                Transform(CreateObject("str"), "HasMinLength", "Contains"),
                Transform(CreateObject("verlylongstring"), "HasMaxLength", "Contains"),
                Transform(CreateObject("string"), "Contains"),
                Transform(CreateObject("teststring"))
            };
        }
    }
}