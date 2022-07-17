using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.Training.LeetCode
{
    /// <summary>
    /// <see href="https://leetcode.com/problems/roman-to-integer/">13. Roman to Integer.</see>
    /// </summary>
    public class RomanToInt
    {
        public int Converter(string str)
        {
            var chars = str.ToList();
            var result = 0;

            for (var i = 0; i < chars.Count; i++)
            {
                if (!IsLastRound(i, chars) &&
                    IsContainsMinusRule(MinusMap, chars, i))
                {
                    result -= NumMap[chars[i]];
                }
                else
                {
                    result += NumMap[chars[i]];
                }
            };

            return result;
        }

        public int Converter_V2(string str)
        {
            return str.Select((item, index) =>
            {
                var firstNum = NumMap[str[index]];
                var secondNum = index + 1 < str.Length ? (int?)NumMap[str[index + 1]] : null;

                if (firstNum < secondNum)
                {
                    return -firstNum;
                }

                return firstNum;
            }).Sum();
        }

        private static readonly Dictionary<char, List<char>> MinusMap = new Dictionary<char, List<char>>
        {
            { 'I', new List<char>() { 'V', 'X' } },
            { 'X', new List<char>() { 'L', 'C' } },
            { 'C', new List<char>() { 'D', 'M' } },
        };

        private static readonly Dictionary<char, int> NumMap = new Dictionary<char, int>
        {
            {'I',1},
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000},
        };

        private bool IsContainsMinusRule(Dictionary<char, List<char>> minusMap, List<char> chars, int i)
        {
            var nowChar = chars[i];
            var nextChar = chars[i + 1];
            return minusMap.ContainsKey(nowChar) &&
                   minusMap[nowChar].Any(a => a == nextChar);
        }

        private bool IsLastRound(int i, List<char> chars)
        {
            return i + 1 >= chars.Count;
        }
    }
}