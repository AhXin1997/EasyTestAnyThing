using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass
{
    public class FizzBuzzClass
    {
        /*
            2022/01/05
            使用 C# 的 for 陳述式逐一查看程式碼區塊

            輸出 1 到 100 的值，每行一個數字。
            當目前的值可由 3 整除時，在該數字旁邊列印 Fizz 字詞。
            當目前的值可由 5 整除時，在該數字旁邊列印 Buzz 字詞。
            當目前的值可由 3 和 5 同時 整除時，在該數字旁邊列印 FizzBuzz 字詞。
       */

        public IEnumerable<string> Run(int count)
        {

            var test = Enumerable.Range(1, count)
                .Select(i => Logic(i))
                .Select((item, index) => Display(item, index));
            return test.ToList();
        }
        private static string Display(string item, int index)
        {
            return $"{index + 1} - {item}";
        }

        private static string Logic(int i)
        {
            var str01 = string.Empty;
            if (i % 3 == 0 && i % 5 == 0) str01 = "FizzBuzz";
            else if (i % 3 == 0) str01 = "Fizz";
            else if (i % 5 == 0) str01 = "Buzz";
            else str01 = "";
            return str01;
        }
    }
}