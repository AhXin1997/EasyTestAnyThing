using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.FizzBuzz
{
    public class NewFizzBuzz : MarkBase
    {
        /// <summary>
        /// 此 StartMethod 模擬 Front-End 使用情況。
        /// 可被 3 整除的標註 Fizz，可被 5 整除的標註 Buzz ，同時被整除的則標註 FizzBuzz。
        /// </summary>
        public void StartMethod()
        {
            MarkMethod(new List<int>(Enumerable.Range(0, 101)))
                .ForEach(f => Console.WriteLine
                (
                    string.IsNullOrWhiteSpace(f.Mark) ?
                    f.Num.ToString() :
                    $"{f.Num} - {f.Mark}"
                ));
        }

        protected override Dictionary<int, string> DividedExactlyMark =>
            new Dictionary<int, string>
            {
                {3, "Fizz"},
                {5, "Buzz"},
            };
    }
}