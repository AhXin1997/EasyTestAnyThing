using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EasyTestAnyThingTest.Training.Algorithm
{
    public class Tests
    {
        /// <summary>
        /// 時間複雜度
        /// https://reurl.cc/d2akGM
        /// https://reurl.cc/j1rEGZ
        /// </summary>

        private readonly ITestOutputHelper _testOutputHelper;

        public Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// 簡易搜尋 O(n)
        /// </summary>
        [Fact]
        public void 簡易搜尋()
        {
            var target = 55;
            var count = 0;
            var numbers = new[] { 5, 17, 33, 41, 55, 61, 80 };

            foreach (var number in numbers)
            {
                count++;
                if (number == target)
                {
                    _testOutputHelper.WriteLine($"用了{count}次,找到{target}.");
                }
            }
        }
        
        /// <summary>
        /// 二分搜尋法 O(log n)
        /// </summary>
        [Theory]
        [InlineData(
            new[] { 5, 17, 33, 41, 55, 61, 80, 111, 123 },
            55,
            55)]
        [InlineData(
            new[] { 5, 17, 33, 41, 55 }, 
            55, 
            55)]
        [InlineData(
            new[] { 55, 60, 72, 88, 93 }, 
            55, 
            55)]
        [InlineData(
            new[] { 2,5,8,50,53,59,63,80 }, 
            55, 
            0)]
        [InlineData(
            new[] { 1, 3, 4, 6, 7, 8, 10, 13, 14 },
            4,
            4)]
        public void 二分搜尋法(int[] arr, int target,int assertNumber)
        {
            var totalLoop = 0;

            var mid = 0;
            var start = 0;
            var end = arr.Count();

            var findNumber = 0;
            while (start <= end)
            {
                totalLoop++;
                mid = (start + end) / 2;

                if (arr[mid] < target)
                {
                    start = mid + 1;
                }
                else if (arr[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    findNumber = arr[mid];
                    break;
                }
            }

            _testOutputHelper.WriteLine($"用了{totalLoop}次,找到{findNumber},於陣列中Index:{mid}");
            findNumber.Should().Be(assertNumber);
        }

        /// <summary>
        /// 給一個陣列，裡面數字都是兩兩存在、但有一個落單的數字，請抓出來
        /// 給[1, 1 ,2]
        /// 要去嘗試手刻GroupBy
        /// </summary>
        [Theory]
        [InlineData(
            new[] { 5, 5, 33, 41, 41, 123, 80, 33, 123 },
            80)]
        [InlineData(
            new[] { 5, 5, 55, 55, 5, 5, 80, 55, 55 },
            80)]
        public void LeetCodeSingleNumber(int[] arr,int target)
        {
            var groupBy = arr.GroupBy(g => g);
            var firstOrDefault = groupBy.FirstOrDefault(s => s.Count() < 2);
            firstOrDefault?.Key.Should().Be(target);
        }

        /// <summary>
        /// 題目給羅馬數字，要把它轉換成阿拉伯數字。比如給”IV”得到數字4、給”VI”會得到6，”DCXXI”得到621。
        /// </summary>
        public void test1()
        {
        }
    }
}