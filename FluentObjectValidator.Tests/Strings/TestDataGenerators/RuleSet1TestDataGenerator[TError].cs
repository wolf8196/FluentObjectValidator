using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Strings.TestDataGenerators
{
    public class RuleSet1TestDataGenerator_TError : StringTestDataGenerator
    {
        public RuleSet1TestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(null), "IsRequired"),
                Transform(CreateObject("")),
                Transform(CreateObject("      ")),
                Transform(CreateObject("verylongstring"), "HasMaxLength"),
                Transform(CreateObject("string"))
            };
        }
    }
}