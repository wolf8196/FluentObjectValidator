using System.Collections;
using System.Collections.Generic;

namespace FluentObjectValidator.Tests
{
    public class BaseTestDataGenerator<TObject> : IEnumerable<object[]>
    {
        private List<object[]> data;

        protected List<object[]> Data { get => data; set => data = value; }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected object[] Transform(TObject obj, bool expected)
        {
            return new object[] { obj, expected };
        }

        protected object[] Transform(TObject obj, params string[] expected)
        {
            return new object[] { obj, expected };
        }
    }
}