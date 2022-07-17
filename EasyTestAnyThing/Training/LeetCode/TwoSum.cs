using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTestAnyThing.Training.LeetCode
{
    /// <summary>
    /// <see href="https://leetcode.com/problems/two-sum/">1. Two Sum.</see>
    /// </summary>
    public class TwoSum
    {
        public int[] Answer_V1(int[] nums, int target)
        {
            for (var mainNumIndex = 0; mainNumIndex < nums.Length; mainNumIndex++)
            {
                for (var afterMainNumIndex = 1 + mainNumIndex; afterMainNumIndex < nums.Length; afterMainNumIndex++)
                {
                    if (nums[mainNumIndex] + nums[afterMainNumIndex] == target)
                    {
                        return new[] { mainNumIndex, afterMainNumIndex };
                    }
                }
            }

            throw new Exception("can't find answer");
        }

        public async Task<int[]> Answer_V2(int[] nums, int target)
        {
            var tasks = new List<Task<object>>();

            for (var mainNumIndex = 0; mainNumIndex < nums.Length; mainNumIndex++)
            {
                for (var afterMainNumIndex = mainNumIndex + 1; afterMainNumIndex < nums.Length; afterMainNumIndex++)
                {
                    var main = mainNumIndex;
                    var after = afterMainNumIndex;
                    tasks.Add(Task.Run(() => FindAnswer(nums, target, main, after)));
                }
            }

            var all = await Task.WhenAll(tasks);
            return (int[])all.First(f => f != null);
        }

        private Task<object> FindAnswer(int[] nums, int target, int i1, int j1)
        { 
            Thread.Sleep(200);
            if (nums[i1] + nums[j1] == target)
            {
                return Task.FromResult<object>(new[] { i1, j1 });
            }
            return Task.FromResult<object>(null);
        }
    }
}