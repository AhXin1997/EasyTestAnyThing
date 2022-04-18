using System.Collections.Generic;
using System.Linq;
using EasyTestAnyThing.MSClassNew.FizzBuzz.Models;

namespace EasyTestAnyThing.MSClassNew.FizzBuzz
{
    public abstract class MarkBase
    {
        protected abstract Dictionary<int, string> DividedExactlyMark { get; }

        /// <summary>
        /// 當傳進的 IEnumerable int 可被 DividedExactlyMark Key 整除, 則標記該 Key 的 Value.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<MarkResult> MarkMethod(IEnumerable<int> list)
        {
            return list.Select(num => new MarkResult()
            {
                Num = num,
                Mark = string.Join
                        (string.Empty,
                            DividedExactlyMark.Where(s => num % s.Key == 0)
                                    .Select(w => w.Value)
                        )
            }).ToList();
        }
    }
}