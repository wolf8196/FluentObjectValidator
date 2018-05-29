using System.Collections.Generic;
using FluentObjectValidator.Tests.FlowBreaker.DTOs;

namespace FluentObjectValidator.Tests.FlowBreaker.TestDataGenerators
{
    public class FlowBreakerTestDataGenerator_TError : BaseTestDataGenerator<FlowDTO>
    {
        public FlowBreakerTestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(1, 25, 15, 25)),
                Transform(CreateObject(null, null, null, null), "IntProp1 IsRequired",
                                                                "IntProp2 IsRequired",
                                                                "IntProp3 IsRequired",
                                                                "IntProp4 IsRequired"),
                Transform(CreateObject(null, 5, null, 5), "IntProp1 IsRequired",
                                                          "IntProp2 HasRule More 10",
                                                          "IntProp3 IsRequired",
                                                          "IntProp4 HasRule More 10",
                                                          "IntProp4 HasRule More 20"),
                Transform(CreateObject(null, 15, null, 5), "IntProp1 IsRequired",
                                                           "IntProp2 HasRule More 20",
                                                           "IntProp3 IsRequired",
                                                           "IntProp4 HasRule More 10",
                                                           "IntProp4 HasRule More 20"),
                Transform(CreateObject(null, 15, 15, 5), "IntProp1 IsRequired",
                                                         "IntProp2 HasRule More 20",
                                                         "IntProp4 HasRule More 10",
                                                         "IntProp4 HasRule More 20"),
                Transform(CreateObject(null, 15, 5, 5), "IntProp1 IsRequired",
                                                        "IntProp2 HasRule More 20",
                                                        "IntProp3 HasRule More 10"),
            };
        }

        private FlowDTO CreateObject(int? prop1, int? prop2, int? prop3, int? prop4)
        {
            return new FlowDTO
            {
                IntProp1 = prop1,
                IntProp2 = prop2,
                IntProp3 = prop3,
                IntProp4 = prop4
            };
        }
    }
}