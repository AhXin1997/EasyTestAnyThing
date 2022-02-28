using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass
{
    public class FizzBuzzClass
    {
        public IEnumerable<string> Run(int count)
        {

            //var test = Enumerable.Range(1, count)
            //    .Select(i => Logic(i))
            //    .Select((item, index) => Display(item, index));
            //return test.ToList();

            var result = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                if (i % 15 == 0)
                {
                    result.Add(i + " - " + "FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add(i + " - " + "Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add(i + " - " + "Buzz");
                }
                else
                {
                    result.Add(i + " - " + "");
                }
            }
            return result;
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