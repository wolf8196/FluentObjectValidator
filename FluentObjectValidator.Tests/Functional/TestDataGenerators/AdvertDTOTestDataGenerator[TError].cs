using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Functional.TestDataGenerators
{
    public class AdvertDTOTestDataGenerator_TError : AdvertDTOTestDataGenerator
    {
        public AdvertDTOTestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject("test", 100.0m, "test", null, new int[]{ 1 })),
                Transform(CreateObject("test", 100.0m, "test", "test", new int[]{ 1 })),
                Transform(CreateObject(null, 100.0m, "test", null, new int[]{ 1 }), "Title IsRequired"),
                Transform(CreateObject("", 100.0m, "test", null, new int[]{ 1 }), "Title IsRequired"),
                Transform(CreateObject("     ", 100.0m, "test", null, new int[]{ 1 }), "Title IsRequired"),
                Transform(CreateObject("te", 100.0m, "test", null, new int[]{ 1 }), "Title HasMinLength"),
                Transform(CreateObject("tes", 100.0m, "test", null, new int[]{ 1 })),
                Transform(CreateObject("testtesttes", 100.0m, "test", null, new int[]{ 1 }), "Title HasMaxLength"),
                Transform(CreateObject("testtestte", 100.0m, "test", null, new int[]{ 1 })),
                Transform(CreateObject("test", null, "test", null, new int[]{ 1 }), "Price IsRequired"),
                Transform(CreateObject("test", new decimal(), "test", null, new int[]{ 1 })),
                Transform(CreateObject("test", 10.0m, null, null, new int[]{ 1 }), "Description IsRequired"),
                Transform(CreateObject("test", 10.0m, "", null, new int[]{ 1 }), "Description IsRequired"),
                Transform(CreateObject("test", 10.0m, "      ", null, new int[]{ 1 }), "Description IsRequired"),
                Transform(CreateObject("test", 10.0m, "testtestte", null, new int[]{ 1 })),
                Transform(CreateObject("test", 10.0m, "testtesttes", null, new int[]{ 1 }), "Description HasMaxLength"),
                Transform(CreateObject("test", 10.0m, "testtest", null, null), "AddressIds IsRequired"),
                Transform(CreateObject("test", 10.0m, "testtest", null, new int[] { }), "AddressIds HasRule"),
                Transform(CreateObject("test", 10.0m, "testtest", null, new int[] { 1, 2, 3, 4 })),
                Transform(CreateObject(null, null, null, null, null), "Title IsRequired",
                                                                      "Price IsRequired",
                                                                      "Description IsRequired",
                                                                      "AddressIds IsRequired"),
                Transform(CreateObject("", null, "     ", null, null), "Title IsRequired",
                                                                      "Price IsRequired",
                                                                      "Description IsRequired",
                                                                      "AddressIds IsRequired"),
                Transform(CreateObject("te", 10.0m, "testtest", null, null), "Title HasMinLength",
                                                                      "AddressIds IsRequired"),
                Transform(CreateObject("testtesttest", 10.0m, "testtesttest", null, null), "Title HasMaxLength",
                                                                      "Description HasMaxLength",
                                                                      "AddressIds IsRequired"),
            };
        }
    }
}