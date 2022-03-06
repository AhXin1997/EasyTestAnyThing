using EasyTestAnyThing.MSClass.New.FizzBizz;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyTestAnyThingTest.MSClass.New.FizzBizz
{
    public class FakeMarkFizzBuzz : MarkFizzBuzz
    {
        protected override IDictionary<int, string> KeyValuePairs
        {
            get => _keyValuePairs;
        }

        public Dictionary<int, string> _keyValuePairs =
            new Dictionary<int, string> { };
    }

    public class MarkFizzBuzzTests
    {
        private readonly FakeMarkFizzBuzz _target;

        public MarkFizzBuzzTests()
        {
            _target = new FakeMarkFizzBuzz();
        }

        [Fact]
        public void MarK_Fizz_When_Num_Can_Be_Divided_Exactly_By_3()
        {
            _target._keyValuePairs.Add(3, "Fizz");

            _target.MarkFizzBuzzMethod(Enumerable.Range(0, 11))
                .Should()
                .BeEquivalentTo(new List<string>
                {
                    "0 - Fizz",
                    "1",
                    "2",
                    "3 - Fizz",
                    "4",
                    "5",
                    "6 - Fizz",
                    "7",
                    "8",
                    "9 - Fizz",
                    "10"
                });
        }

        [Fact]
        public void MarK_Buzz_When_Num_Can_Be_Divided_Exactly_By_5()
        {
            _target._keyValuePairs.Add(5, "Buzz");

            _target.MarkFizzBuzzMethod(Enumerable.Range(0, 11))
                .Should()
                .BeEquivalentTo(new List<string>
                {
                    "0 - Buzz",
                    "1",
                    "2",
                    "3",
                    "4",
                    "5 - Buzz",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10 - Buzz"
                });
        }

        [Fact]
        public void MarK_FizzBuzz_When_Num_Can_Be_Divided_Exactly_By_3_And_5()
        {
            _target._keyValuePairs.Add(3, "Fizz");
            _target._keyValuePairs.Add(5, "Buzz");

            _target.MarkFizzBuzzMethod(Enumerable.Range(0, 16))[15]
                .Should().Be("15 - FizzBuzz");
            //.BeEquivalentTo(new List<string>
            //{
            //    "0 - FizzBuzz",
            //    "1",
            //    "2",
            //    "3 - Fizz",
            //    "4",
            //    "5 - Buzz",
            //    "6 - Fizz",
            //    "7",
            //    "8",
            //    "9 - Fizz",
            //    "10 - Buzz"
            //});
        }
    }
}