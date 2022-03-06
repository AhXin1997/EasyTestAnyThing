using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.FizzBizz
{
    public class MarkFizzBuzz
    {
        /// <summary>
        /// 3的倍數印Fizz、5的倍數印Buzz
        /// </summary>
        public void StartMethod()
        {
            MarkFizzBuzzMethod(new List<int>(Enumerable.Range(0, 101)))
                .ForEach(f => Console.WriteLine(f));
        }

        public List<string> MarkFizzBuzzMethod(IEnumerable<int> list)
        {
            var outputStr = string.Empty;
            foreach (var num in list)
            {
                var valueWords = new List<string>();
                valueWords.AddRange(
                    KeyValuePairs
                        .Where(s => num % s.Key == 0)
                        .Select(w => w.Value)
                );
                var str = string.Join(string.Empty, valueWords);
                outputStr += string.IsNullOrWhiteSpace(str) ?
                            $"{num}," :
                            $"{num} - {str},";
            }

            return new List<string>
                (
                    outputStr.Remove(outputStr.Length - 1, 1)
                    .Split(',')
                    .ToList()
                );
        }

        protected virtual IDictionary<int, string> KeyValuePairs
        {
            get => _keyValuePairs;
        }

        private readonly Dictionary<int, string> _keyValuePairs = new Dictionary<int, string>
        {
            {3,"Fizz"},
            {5,"Buzz"},
            {7,"Moly"},
            {15,"Hot"},
        };
    }
}