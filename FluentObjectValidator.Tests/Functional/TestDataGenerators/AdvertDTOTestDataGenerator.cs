using System.Collections.Generic;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.TestDataGenerators
{
    public class AdvertDTOTestDataGenerator : BaseTestDataGenerator<AdvertDTO>
    {
        public AdvertDTOTestDataGenerator()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject("test", 100.0m, "test", null, new int[]{ 1 }), true),
                Transform(CreateObject("test", 100.0m, "test", "test", new int[]{ 1 }), true),
                Transform(CreateObject(null, 100.0m, "test", null, new int[]{ 1 }), false),
                Transform(CreateObject("", 100.0m, "test", null, new int[]{ 1 }), false),
                Transform(CreateObject("     ", 100.0m, "test", null, new int[]{ 1 }), false),
                Transform(CreateObject("te", 100.0m, "test", null, new int[]{ 1 }), false),
                Transform(CreateObject("tes", 100.0m, "test", null, new int[]{ 1 }), true),
                Transform(CreateObject("testtesttes", 100.0m, "test", null, new int[]{ 1 }), false),
                Transform(CreateObject("testtestte", 100.0m, "test", null, new int[]{ 1 }), true),
                Transform(CreateObject("test", null, "test", null, new int[]{ 1 }), false),
                Transform(CreateObject("test", new decimal(), "test", null, new int[]{ 1 }), true),
                Transform(CreateObject("test", 10.0m, null, null, new int[]{ 1 }), false),
                Transform(CreateObject("test", 10.0m, "", null, new int[]{ 1 }), false),
                Transform(CreateObject("test", 10.0m, "      ", null, new int[]{ 1 }), false),
                Transform(CreateObject("test", 10.0m, "testtestte", null, new int[]{ 1 }), true),
                Transform(CreateObject("test", 10.0m, "testtesttes", null, new int[]{ 1 }), false),
                Transform(CreateObject("test", 10.0m, "testtest", null, null), false),
                Transform(CreateObject("test", 10.0m, "testtest", null, new int[] { }), false),
                Transform(CreateObject("test", 10.0m, "testtest", null, new int[] { 1, 2, 3, 4 }), true),
                Transform(CreateObject(null, null, null, null, null), false),
                Transform(CreateObject("", null, "     ", null, null), false),
                Transform(CreateObject("te", 10.0m, "testtest", null, null), false),
                Transform(CreateObject("testtesttest", 10.0m, "testtesttest", null, null), false)
            };
        }

        protected AdvertDTO CreateObject(string title, decimal? price, string descr, string photo, int[] addressIds)
        {
            return new AdvertDTO
            {
                Title = title,
                Price = price,
                Description = descr,
                PhotoBase64 = photo,
                AddressIds = addressIds
            };
        }
    }
}