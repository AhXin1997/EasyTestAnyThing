using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.FizzBizz
{
    /*
     * 3的倍數印Fizz、5的倍數印Buzz
     */

    public class MarkFizzBuzz
    {
        public void StartMethod()
        {
            var x = new List<int>();
            for (int i = 0; i < 101; i++)
            {
                x.Add(i);
            };
            var w = MarkFizzBuzzMethod01(x);
            w.ForEach(f => Console.WriteLine(f));
        }

        public List<string> MarkFizzBuzzMethod(List<int> list)
        {
            var str = string.Empty;
            foreach (var item in list)
            {
                str += item + " ";
                if (item % 3 == 0) str += "Fizz";
                if (item % 5 == 0) str += "Buzz";
                if (item % 7 == 0) str += "Hot";
                str += ",";
            }
            return new List<string>
                (
                    str.Remove(str.Length - 1, 1)
                    .Split(',')
                    .Select(s => s.Trim())
                    .ToList()
                ); ;
        }

        public Dictionary<int, string> keyValuePairs = new Dictionary<int, string> 
        {
            {3,"Fizz"},
            {5,"Buzz"},
            {15,"Hot"},
            {7,"Omg"},
        };

        public List<string> MarkFizzBuzzMethod01(List<int> list)
        {
            var str = string.Empty;
            var x = new List<string>();
            foreach (var num in list)
            {
                foreach (var item in keyValuePairs)
                {
                    if (num % item.Key == 0)
                    {
                        x.Add(item.Value);
                    }
                    else
                    {
                        x.Add("");
                    }
                }

                str += num;
                foreach (var ggg in x)
                {
                    str += ggg;
                }
                str += ",";

                x.Clear();
            }

            return new List<string>
                (
                    str.Remove(str.Length - 1, 1)
                    .Split(',')
                    .ToList()
                );
        }
    }
}