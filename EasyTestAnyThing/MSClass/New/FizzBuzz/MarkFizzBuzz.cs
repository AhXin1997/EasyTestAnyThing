using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.FizzBuzz
{
    public class MarkFizzBuzz
    {
        //markService
        //FizzBuzzClass

        /// <summary>
        /// 3的倍數印Fizz、5的倍數印Buzz
        /// </summary>
        public void StartMethod()
        {
            MarkFizzBuzzMethod(new List<int>(Enumerable.Range(0, 101)))
                .ForEach(f => Console.WriteLine
                (
                    string.IsNullOrWhiteSpace(f.Mark) ?
                    f.Num.ToString():
                    $"{f.Num} - {f.Mark}"
                ));

        }

        public List<FizzBuzzResult> MarkFizzBuzzMethod(IEnumerable<int> list)
        {
            return list.Select(num => new FizzBuzzResult()
                {
                    Num = num,
                    Mark = string.Join
                        (string.Empty, 
                         KeyValuePairs.Where(s => num % s.Key == 0)
                                    .Select(w => w.Value)
                        )
                })
                .ToList();
        }

        public class FizzBuzzResult

        {
            public int Num { get; set; }
            public string Mark { get; set; }
        }

        protected virtual IDictionary<int, string> KeyValuePairs => _keyValuePairs;

        private readonly Dictionary<int, string> _keyValuePairs = new Dictionary<int, string>
        {
            {2,""},
            {3,"Fizz"},
            {5,"Buzz"},
            {7,"Moly"},
            {15,"Hot"},
        };
    }
}