using FluentAssertions;
using Xunit;

namespace EasyTestAnyThingTest.Training.LeetCode
{
    public class LeetCode
    {
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanToInt(string s, int assertNum)
        {
            EasyTestAnyThing.Training.LeetCode.RomanToInt.Converter(s).Should().Be(assertNum);
        }
    }
}
