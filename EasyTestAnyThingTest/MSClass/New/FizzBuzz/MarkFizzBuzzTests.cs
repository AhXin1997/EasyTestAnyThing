using EasyTestAnyThing.MSClass.New.FizzBuzz;
using EasyTestAnyThing.MSClass.New.FizzBuzz.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyTestAnyThingTest.MSClass.New.FizzBuzz
{
    public class MarkMethodTests
    {
        private readonly FizzBuzzClass _target;

        public MarkMethodTests()
        {
            _target = new FizzBuzzClass();
        }

        [Fact]
        public void Mark_Fizz_Buzz_StartWith_14_Count_5_When_Num_Can_Be_Divided_Exactly_By_3_And_5()
        {
            _target.MarkMethod(Enumerable.Range(14, 5))
                .Should()
                .BeEquivalentTo(new List<MarkResult>
                {
                    new MarkResult{ Num = 14, Mark = string.Empty },
                    new MarkResult{ Num = 15, Mark = "FizzBuzz" },
                    new MarkResult{ Num = 16, Mark = string.Empty },
                    new MarkResult{ Num = 17, Mark = string.Empty },
                    new MarkResult{ Num = 18, Mark = "Fizz" },
                });
        }

        [Fact]
        public void Mark_Fizz_Buzz_StartWith_92_Count_5_When_Num_Can_Be_Divided_Exactly_By_3_And_5()
        {
            _target.MarkMethod(Enumerable.Range(92, 5))
                .Should()
                .BeEquivalentTo(new List<MarkResult>
                {
                    new MarkResult{ Num = 92, Mark = string.Empty },
                    new MarkResult{ Num = 93, Mark = "Fizz" },
                    new MarkResult{ Num = 94, Mark = string.Empty },
                    new MarkResult{ Num = 95, Mark = "Buzz" },
                    new MarkResult{ Num = 96, Mark = "Fizz" },
                });
        }
    }
}