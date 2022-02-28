using FluentAssertions;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class StringSumAndNumSumTests
    {
        private StringSumAndNumSum _stringSumAndNumSum;

        public StringSumAndNumSumTests()
        {
            _stringSumAndNumSum = new StringSumAndNumSum();
        }

        [Fact]
        public void StringSumAndNumSumMethodTest()
        {
            //Arrange
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };

            //Act
            var target = _stringSumAndNumSum.StringSumAndNumSumMethod(values);

            //Assert
            target.Should().Be("Message:ABCDEF\nTotal:68.3");
        }
    }
}