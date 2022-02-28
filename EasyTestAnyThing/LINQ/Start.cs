using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.LINQ
{
    public class Start
    {
        private static List<User> Data => MockData.Data;

        public static void StartMethod()
        {
            HowToUseWhere("AhXin", true);
            HowToUseWhereContains("Ah", true);
            HowToUseSelect("AhXin", true);
            HowToUseOrderby(true);
            HowToUseOrderByDescending(true);
        }

        /// <summary>
        /// 尋找該位使用者
        /// </summary>
        private static void HowToUseWhere(string name, bool newStyle)
        {
            Console.WriteLine(nameof(HowToUseWhere));

            if (newStyle)
            {
                var nameEqualsAhxinData = Data.Where(w => w.Name == name).FirstOrDefault();
                Console.WriteLine
                    (
                        nameEqualsAhxinData.Name + "\t" +
                        nameEqualsAhxinData.Age + "\t"
                    );
            }
            else
            {
                var whereUser = from s in Data where s.Name == name select s;
                var user = whereUser.FirstOrDefault();
                Console.WriteLine(user.Name + "\t" + user.Age + "\t");
            }
        }

        /// <summary>
        /// 模糊搜尋使用者名稱
        /// </summary>
        /// <param name="name"></param>
        private static void HowToUseWhereContains(string name, bool newStyle)
        {
            if (newStyle)
            {
                Console.WriteLine(nameof(HowToUseWhereContains));
                var nameEqualsAhxinData = Data.Where(w => w.Name.Contains(name)).FirstOrDefault();
                Console.WriteLine
                    (
                        nameEqualsAhxinData.Name + "\t" +
                        nameEqualsAhxinData.Age + "\t"
                    );
            }
            else
            {
                var whereUser = from s in Data where s.Name.Contains(name) select s;
                var user = whereUser.FirstOrDefault();
                Console.WriteLine(user.Name + "\t" + user.Age + "\t");
            }
        }

        /// <summary>
        /// 尋找該位使用者的年齡
        /// </summary>
        /// <param name="name"></param>
        private static void HowToUseSelect(string name, bool newStyle)
        {
            if (newStyle)
            {
                Console.WriteLine(nameof(HowToUseSelect));
                var selectName = Data.Where(w => w.Name == name).Select(s => s.Age).FirstOrDefault();
                Console.WriteLine(selectName);
            }
            else
            {
                var whereUser = from s in Data where s.Name == name select s.Age;
                var userAge = whereUser.FirstOrDefault();
                Console.WriteLine(userAge);
            }
        }

        /// <summary>
        /// Orderby Age 年紀最小至最大
        /// </summary>
        private static void HowToUseOrderby(bool newStyle)
        {
            if (newStyle)
            {
                Console.WriteLine(nameof(HowToUseOrderby));
                var oderbyAge = Data.OrderBy(o => o.Age);
                oderbyAge.ToList().ForEach(f =>
                    Console.WriteLine
                    (
                        f.Name + "\t" +
                        f.Age + "\t"
                    )
                );
            }
            else
            {
                var sorting = from s in Data orderby s.Age select s;
                var users = sorting.ToList();
                users.ForEach(f => Console.WriteLine(f.Name + "\t" + f.Age));
            }
        }

        /// <summary>
        /// OrderByDescending 年紀最大至最小
        /// </summary>
        private static void HowToUseOrderByDescending(bool newStyle)
        {
            if (newStyle)
            {
                Console.WriteLine(nameof(HowToUseOrderByDescending));
                var oderbyAge = Data.OrderByDescending(o => o.Age);
                oderbyAge.ToList().ForEach(f =>
                    Console.WriteLine
                    (
                        f.Name + "\t" +
                        f.Age + "\t"
                    )
                );
            }
            else
            {
                var sorting = from s in Data orderby s.Age descending select s;
                var users = sorting.ToList();
                users.ForEach(f => Console.WriteLine(f.Name + "\t" + f.Age));
            }
        }

        private static class MockData
        {
            public static List<User> Data =>
                new List<User>
                {
                    new User { Name = "AhXin" , Age = 20 },
                    new User { Name = "Will" , Age = 32 },
                    new User { Name = "Hugo" , Age = 45 },
                    new User { Name = "Bunny" , Age = 18 },
                    new User { Name = "Jack" , Age = 22 },
                };
        }

        private class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}