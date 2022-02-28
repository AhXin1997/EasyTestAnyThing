using FluentAssertions;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class ReverseCharTests
    {
        private ReverseChar _reverseChar;

        public ReverseCharTests()
        {
            _reverseChar = new ReverseChar();
        }

        [Fact]
        public void ReverseCharMethodTest_OneWord_Reverse()
        {
            //Arrange
            var data = "The";
            var expected = "ehT";

            //Act
            var actual = _reverseChar.ReverseCharMethod(data);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ReverseCharMethodTest_TwoWord_Reverse()
        {
            //Arrange
            var data = "The First";
            var expected = "ehT tsriF";

            //Act
            var actual = _reverseChar.ReverseCharMethod(data);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}