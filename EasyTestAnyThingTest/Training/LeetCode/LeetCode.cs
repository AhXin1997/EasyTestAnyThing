using System;
using System.Collections.Generic;
using System.Linq;
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

        [Theory]
        [InlineData(new []{ 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new []{ 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new []{ 3, 3 }, 6, new[] { 0, 1 })]
        [InlineData(new []{ 2, 5, 5, 11 }, 10, new[] { 1, 2 })]
        public void TwoSum(int[] nums,int target,int[] answer)
        {
            var list = new List<int>();

            for (var i = 0; i < nums.Length && !list.Any(); i++)
            {
                for (var j = 1; j < nums.Length && 
                                !list.Any(); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (nums[i] + nums[j] == target)
                    {
                        list.AddRange(new []{i , j});
                    }
                }
            }

            answer.Should().BeEquivalentTo(list.ToArray());
        }
    }
}
