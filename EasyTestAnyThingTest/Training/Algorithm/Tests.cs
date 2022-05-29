using System;
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
        [Fact]
        public void 二分搜尋法()
        {
            var target = 55;
            var count = 0;

            var numbers = new[] { 5, 17, 33, 41, 55, 61, 80, 111, 123 };
            var halfCount = (int)Math.Floor(numbers.Count() / 2d);
            var indexNumber = 0;

            var doubleIndex = 0;
            var halvingIndex = 0;

            while (target != indexNumber)
            {
                count++;
                indexNumber = numbers[halfCount];

                //目標數字 大於 當前數字
                //將Index * 2
                //找出下一區域的中間值
                if (target > indexNumber)
                {
                    halfCount *= 2;
                    doubleIndex = halfCount;
                }

                //目標數字 小於 當前數字
                //將Index / 2
                //找出上一區域的中間值
                if (target < indexNumber)
                {
                    halfCount /= 2;
                    halvingIndex = halfCount;
                }

                if (doubleIndex - halvingIndex == 3)
                {
                    halfCount++;
                    break;
                }
            }
            _testOutputHelper.WriteLine($"用了{count}次,找到{numbers[halfCount]}.");
        }

        /// <summary>
        /// 給一個陣列，裡面數字都是兩兩存在、但有一個落單的數字，請抓出來
        /// 給[1, 1 ,2]
        /// </summary>
        public void test()
        {
        }

        /// <summary>
        /// 題目給羅馬數字，要把它轉換成阿拉伯數字。比如給”IV”得到數字4、給”VI”會得到6，”DCXXI”得到621。
        /// </summary>
        public void test1()
        {
        }
    }
}