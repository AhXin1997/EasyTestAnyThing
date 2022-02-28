using FluentAssertions;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class RemainderMarkTests
    {
        private RemainderMark _target;

        public RemainderMarkTests()
        {
            _target = new RemainderMark();
        }

        [Fact]
        public void RemainderMarkMethodTest_5()
        {
            //Arrange
            var expected = "5 - Buzz";

            //Act
            var actual = _target.RemainderMarkMethod();

            //Assert
            actual[4].Should().Be(expected);
        }

        [Fact]
        public void RemainderMarkMethodTest_3()
        {
            //Arrange
            var expected = "3 - Fizz";

            //Act
            var actual = _target.RemainderMarkMethod();

            //Assert
            actual[2].Should().Be(expected);
        }

        [Fact]
        public void RemainderMarkMethodTest_Cant_Not_Be_Remainder()
        {
            //Arrange
            var expected = "2 - ";

            //Act
            var actual = _target.RemainderMarkMethod();

            //Assert
            actual[1].Should().Be(expected);
        }
    }
}