using System;
using System.Collections.Generic;

namespace EasyTestAnyThing.IfNull
{
    /*
     * 探討判斷 Null 的運算式
     * 與有可能陷入的誤區
     */

    public static class Start
    {
        /// <summary>
        /// Try Enter null or abc or string.Empty
        /// </summary>
        public static void StartMethod(string str)
        {
            Name = str;
            var y = new List<string>() { Name01, Name02, Name03, Name04 };
            y.ForEach(f => Console.WriteLine(f));
        }

        public static string Name { get; set; }
        public static string IfIsNullThanSetThisWord => "Word";

        /// <summary>
        /// If not Null than Name.ToUpper(), Else return IfIsNullThanSetThisWord.
        /// </summary>
        public static string Name01 => Name != null ? Name.ToUpper() : IfIsNullThanSetThisWord;

        /// <summary>
        /// If not Null than Name.ToUpper(), Else return null.
        /// </summary>
        public static string Name02 => Name?.ToUpper();

        /// <summary>
        /// If not Null than return Name, Else return IfIsNullThanSetThisWord.
        /// </summary>
        public static string Name03 => Name ?? IfIsNullThanSetThisWord;

        /// <summary>
        /// If not Null than return Name, Else return IfIsNullThanSetThisWord.
        /// </summary>
        public static string Name04
        {
            get
            {
                if (Name != null)
                {
                    return Name.ToUpper();
                }
                else
                {
                    return IfIsNullThanSetThisWord;
                }
            }
        }
    }
}