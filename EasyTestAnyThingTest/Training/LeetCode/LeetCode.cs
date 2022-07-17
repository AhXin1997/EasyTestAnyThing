using System.Threading.Tasks;
using EasyTestAnyThing.Training.LeetCode;
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
        public void RomanToInt_V1(string s, int assertNum)
        {
            var result = new RomanToInt().Converter(s);
            result.Should().Be(assertNum);
        }
        
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanToInt_V2(string s, int assertNum)
        {
            var result = new RomanToInt().Converter_V2(s);
            result.Should().Be(assertNum);
        }

        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        [InlineData(new[] { 0, 1, 1, 0 }, 0, new[] { 0, 3 })]
        [InlineData(new[] { 2, 5, 5, 11 }, 10, new[] { 1, 2 })]
        public void TwoSum_V1(int[] nums, int target, int[] answer)
        {
            var result = new TwoSum().Answer_V1(nums, target);
            result.Should().BeEquivalentTo(answer);
        }
        
        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        [InlineData(new[] { 0, 1, 1, 0 }, 0, new[] { 0, 3 })]
        [InlineData(new[] { 2, 5, 5, 11 }, 10, new[] { 1, 2 })]
        public async Task TwoSum_V2(int[] nums, int target, int[] answer)
        {
            var result = await new TwoSum().Answer_V2(nums, target);
            result.Should().BeEquivalentTo(answer);
        }
    }
}