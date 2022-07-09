﻿using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.Training.LeetCode
{
    /// <summary>
    /// <see href="https://leetcode.com/problems/roman-to-integer/">13. Roman to Integer.</see>
    /// </summary>
    public static class RomanToInt
    {
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

        public static int Converter(string srt)
        {
            var chars = srt.ToList();
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

        private static bool IsContainsMinusRule(Dictionary<char, List<char>> minusMap, List<char> chars, int i)
        {
            var nowChar = chars[i];
            var nextChar = chars[i + 1];
            return minusMap.ContainsKey(nowChar) &&
                   minusMap[nowChar].Any(a => a == nextChar);
        }

        private static bool IsLastRound(int i, List<char> chars)
        {
            return i + 1 >= chars.Count;
        }
    }
}