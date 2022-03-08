using EasyTestAnyThing.MSClass.New.FizzBuzz.Models;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.FizzBuzz
{
    public abstract class MarkBase
    {
        private IDictionary<int, string> KeyValuePairs => DividedExactlyMark;
        protected abstract Dictionary<int, string> DividedExactlyMark { get; }

        /// <summary>
        /// 當傳進的 IEnumerable int 可被 DividedExactlyMark Key 整除, 則標記該 Key 的 Value.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<MarkResult> MarkMethod(IEnumerable<int> list)
        {
            return list.Select(num => new MarkResult()
            {
                Num = num,
                Mark = string.Join
                        (string.Empty,
                         KeyValuePairs.Where(s => num % s.Key == 0)
                                    .Select(w => w.Value)
                        )
            }).ToList();
        }
    }
}