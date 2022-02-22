using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.Tuple
{
    public static class Start
    {
        /*
         * 學習 Tuple 用法
         */

        private static string BaseString => "MethodName : {0}\nName : {1}\tAge : {2}\n";
        public static void StartMethod()
        {
            var tuple = Tuple("AhXin", 49);
            Console.WriteLine(string.Format(BaseString, nameof(Tuple), tuple.Item1, tuple.Item2));

            var valueTuple = ValueTuple("AhXin", 49);
            Console.WriteLine(string.Format(BaseString, nameof(ValueTuple), valueTuple.Item1, valueTuple.Item2));

            var valueTupleShowName = GetOnePerson();
            Console.WriteLine(string.Format(BaseString, nameof(GetOnePerson), valueTupleShowName.Name, valueTupleShowName.Age));

            SimpleGetData()
                .ForEach(f => Console.WriteLine(string.Format(BaseString, nameof(SimpleGetData), f.Name, f.Age)));

            UsageOut("AhXin", 49, out string name, out int age);
            Console.WriteLine(string.Format(BaseString,nameof(UsageOut), name, age));
        }

        /// <summary>
        /// Tuple 第一種用法 外界無法得知T1,T2為甚麼 會顯示Item1,Item2
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public static Tuple<string, int> Tuple(string name, int age)
        {
            return new Tuple<string, int>(name, age);
        }

        /// <summary>
        /// ValueTuple 第一種用法 外界無法得知T1,T2為甚麼 會顯示Item1,Item2
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public static (string, int) ValueTuple(string name, int age)
        {
            return (name, age);
        }

        /// <summary>
        /// 明確指示欄位名稱以便使用
        /// </summary>
        /// <returns></returns>
        public static (string Name, int Age) GetOnePerson()
        {
            return SimpleGetData().FirstOrDefault(w => w.Name == "Joe");
        }

        /// <summary>
        /// 要模擬資料並且懶得建立新物件可以這樣寫
        /// </summary>
        /// <returns></returns>
        public static List<(string Name, int Age)> SimpleGetData()
        {
            return new List<(string Name, int Age)>
            {
                ("Joe",1),
                ("Monica",18),
                ("Chandler",58)
            };
        }

        /// <summary>
        /// 用 Out 達到相同於 Tuple 的效果
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="name01"></param>
        /// <param name="age01"></param>
        public static void UsageOut(string name, int age, out string name01, out int age01)
        {
            name01 = name;
            age01 = age;
        }
    }
}