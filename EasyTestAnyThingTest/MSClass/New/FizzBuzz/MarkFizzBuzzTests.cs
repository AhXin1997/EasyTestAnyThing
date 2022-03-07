using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using EasyTestAnyThing.MSClass.New.FizzBuzz;
using Xunit;
using EasyTestAnyThing.MSClass.New.FizzBuzz.Models;

namespace EasyTestAnyThingTest.MSClass.New.FizzBuzz
{
    public class MarkFizzBuzzTests
    {
        private readonly FizzBuzzClass _target;

        public MarkFizzBuzzTests()
        {
            _target = new FizzBuzzClass();
        }

        [Fact]
        public void Mark_Fizz_Buzz_StartWith_14_Count_5_When_Num_Can_Be_Divided_Exactly_By_3_And_5()
        {
            _target.MarkFizzBuzz(Enumerable.Range(14, 5))
                .Should()
                .BeEquivalentTo(new List<FizzBuzzResult>
                {
                    new FizzBuzzResult{ Num = 14, Mark = string.Empty },
                    new FizzBuzzResult{ Num = 15, Mark = "FizzBuzz" },
                    new FizzBuzzResult{ Num = 16, Mark = string.Empty },
                    new FizzBuzzResult{ Num = 17, Mark = string.Empty },
                    new FizzBuzzResult{ Num = 18, Mark = "Fizz" },
                });
        }

        [Fact]
        public void Mark_Fizz_Buzz_StartWith_92_Count_5_When_Num_Can_Be_Divided_Exactly_By_3_And_5()
        {
            _target.MarkFizzBuzz(Enumerable.Range(92, 5))
                .Should()
                .BeEquivalentTo(new List<FizzBuzzResult>
                {
                    new FizzBuzzResult{ Num = 92, Mark = string.Empty },
                    new FizzBuzzResult{ Num = 93, Mark = "Fizz" },
                    new FizzBuzzResult{ Num = 94, Mark = string.Empty },
                    new FizzBuzzResult{ Num = 95, Mark = "Buzz" },
                    new FizzBuzzResult{ Num = 96, Mark = "Fizz" },
                });
        }
    }
}