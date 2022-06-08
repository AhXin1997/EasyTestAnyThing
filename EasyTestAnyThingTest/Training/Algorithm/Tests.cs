﻿using FluentAssertions;
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
            new[] { 2, 5, 8, 50, 53, 59, 63, 80 },
            55,
            0)]
        [InlineData(
            new[] { 1, 3, 4, 6, 7, 8, 10, 13, 14 },
            4,
            4)]
        public void 二分搜尋法(int[] arr, int target, int assertNumber)
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
        /// </summary>
        [Theory]
        [InlineData(
            new[] { 5, 5, 33, 41, 41, 123, 80, 33, 123 },
            80)]
        [InlineData(
            new[] { 5, 5, 55, 55, 5, 5, 80, 55, 55 },
            80)]
        public void SingleNumber(int[] arr, int target)
        {
            arr.GroupBy(g => g)
                .First(s => s.Count() < 2).Key
                .Should()
                .Be(target);
        }

        /// <summary>
        /// 自刻GroupBy
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(
            new[] { 5, 5, 33, 41, 41, 123, 80, 33, 123 },
            80)]
        [InlineData(
            new[] { 5, 5, 55, 55, 5, 5, 80, 55, 55 },
            80)]
        public void SingleNumberGroupBy(int[] arr, int target)
        {
            var selfGroupBy = new Dictionary<int, List<int>>();
            foreach (var key in arr)
            {
                if (selfGroupBy.ContainsKey(key)) continue;
                selfGroupBy.Add(key, arr.Where(value => key == value).ToList());
            }

            var firstOrDefault = selfGroupBy.FirstOrDefault(s => s.Value.Count < 2);
            firstOrDefault.Key.Should().Be(target);
        }

        /// <summary>
        /// 題目給羅馬數字，要把它轉換成阿拉伯數字。比如給”IV”得到數字4、給”VI”會得到6，”DCXXI”得到621。
        /// </summary>
        [Theory]
        [InlineData("IV", 4)]
        [InlineData("CXCIX", 199)]
        [InlineData("DCXXI", 621)]
        [InlineData("DCCC", 800)]
        [InlineData("MCDXXXVII", 1437)]
        [InlineData("MMMCCCXXXIII", 3333)]
        public void RomanToArabicNumber(string request, int target)
        {
            var romanNumberDictionary = new Dictionary<string, int>()
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 },
            };

            var isAllowMinus = new List<char>()
            {
                'I', 'X', 'C'
            };

            int answer = default;
            int lastNumber = default;
            char lastWord = default;
            var isFirstTime = true;

            foreach (var word in request)
            {
                var number = romanNumberDictionary[word.ToString()];
                if (number > lastNumber &&
                    isAllowMinus.Contains(lastWord) &&
                    !isFirstTime)
                {
                    answer -= (lastNumber * 2) - number;
                }
                else
                {
                    answer += number;
                }

                isFirstTime = false;
                lastNumber = number;
                lastWord = word;
            }

            Math.Abs(answer).Should().Be(target);
        }

        /// <summary>
        /// Input: numbers = [2,7,11,15], target = 9
        /// Output: [1,2]
        /// Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
        /// 請找已排序陣列(小到大)裡，哪兩個數字(相對位置)總和等於 target
        /// </summary>
        [Theory]
        [InlineData(
            new[] { 5, 8, 15, 30, 68 },
            73,
            new[] { 1, 5 })]
        [InlineData(
            new[] { 5, 23, 88, 450, 1280, 1999, 2224, 3852, 10059 },
            11339,
            new[] { 5, 9 })]
        public void TwoSum(int[] numbers, int target, int[] relativeIndexShouldBe)
        {
            var catchRelativeIndex = new int[2];
            var i0index = 0;
            var i1index = 0;

            var x = false;
            
            foreach (var i0 in numbers)
            {
                foreach (var i1 in numbers)
                {
                    if (i0 + i1 == target)
                    {
                        catchRelativeIndex.SetValue(++i0index, 0);
                        catchRelativeIndex.SetValue(++i1index, 1);
                        x = true;
                        break;
                    }
                    i1index++;
                }
                if (x)
                {
                    break;
                }
                i0index++;
                i1index = 0;
            }

            catchRelativeIndex.Should().BeEquivalentTo(relativeIndexShouldBe);
        }

        /// <summary>
        /// input: 給一個沒有負數的數字陣列
        ///     output: 回傳前面是偶數後面是奇數的陣列
        ///
        /// Example 1:
        /// Input: [3,1,2,4]
        /// Output: [2,4,3,1]
        /// The outputs[4, 2, 3, 1], [2, 4, 1, 3], and[4, 2, 1, 3] would also be accepted.
        /// </summary>
        public void SortArrayByParity(string request, int target)
        {
        }

        /// <summary>
        /// https://leetcode.cn/problems/remove-element/
        /// 输入：nums = [3,2,2,3], val = 3
        /// 输出：2, nums = [2,2]
        /// 解释：函数应该返回新的长度 2, 并且 nums 中的前两个元素均为 2。
        /// 你不需要考虑数组中超出新长度后面的元素。
        /// 例如，函数返回的新长度为 2 ，
        /// 而 nums = [2, 2, 3, 3] 或 nums = [2, 2, 0, 0]，也会被视作正确答案。
        /// </summary>
        [Theory]
        [InlineData(
            new[] { 5, 41, 41, 33, 123 },
            41,
            new[] { 5, 33, 123 },
            3)]
        [InlineData(
            new[] { 5, 5, 55, 55, 5, 5, 80, 55, 55 },
            5,
            new[] { 55, 55, 55, 55, 80 },
            3)]
        public void RemoveElement(int[] arr, int removeNumber, int[] newArr, int newArrCount)
        {
        }

        /*
         * 綜合應用 -- 隨機分配飯店分房睡
         * 問題 : 這十二位到日本七天六夜旅遊
         * 現在有三間飯店
         * 這十二位旅行人
         * 十二位旅行者 隨機分配到四間大飯店
         *
         * 步驟
         * 1. 需要取得數據
         * 取得12為 旅行者數據 -- 列表
         * 取得四間大飯店的數據 -- 列表勘套
         * 奈良溫泉 加賀屋溫泉 大板根溫泉 草津溫泉
         *
         * 2. 分配旅遊者到大飯店 分房
         * ***隨機分配
         * 把旅行者明子導入到大飯店列表
         *
         * 3. 驗證是否分配成功
         * 列印出大飯店詳細訊息
         * 每間大飯店的人數和對應旅行者的名字
         *
         */

        [Theory]
        [InlineData(
            new[] { "man01", "man02","man03", "man04","man05", "man06",
                "woman01", "woman02","woman03", "woman04","woman05", "woman06",},
            new[] { "奈良溫泉", "加賀屋溫泉", "大板根溫泉", "草津溫泉" })]
        public void RandomSleep(string[] traveler, string[] hotSpringHotel)
        {
        }
    }
}