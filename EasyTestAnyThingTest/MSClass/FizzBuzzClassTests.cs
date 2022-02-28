using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class FizzBuzzClassTests
    {
        [Fact]
        public void Test1()
        {
            var target = new FizzBuzzClass();
            var actual = target.Run(1);

            actual.Should().BeEquivalentTo(new[]
            {
                "1 - "
            });
        }

        [Fact]
        public void Test2()
        {
            var target = new FizzBuzzClass();
            var actual = target.Run(3);

            actual.Should().BeEquivalentTo(new[]
            {
                "1 - ","2 - ","3 - Fizz"
            });
        }

        [Fact]
        public void Test3()
        {
            var target = new FizzBuzzClass();
            var actual = target.Run(5);

            actual.Should().BeEquivalentTo(new[]
            {
                "1 - ","2 - ","3 - Fizz","4 - ","5 - Buzz"
            });
        }

        [Fact]
        public void Test4()
        {
            var target = new FizzBuzzClass();
            IEnumerable<string> actual = target.Run(15);
            foreach (var item in actual)
            {
                var test = item;
            }

            actual.Should().BeEquivalentTo(new[]
            {
                "1 - ","2 - ","3 - Fizz","4 - ","5 - Buzz",
                "6 - Fizz","7 - ","8 - ","9 - Fizz","10 - Buzz",
                "11 - ","12 - Fizz","13 - ","14 - ","15 - FizzBuzz",
            });
        }
    }
}