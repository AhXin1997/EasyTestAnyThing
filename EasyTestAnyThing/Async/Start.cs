using System;
using System.Threading.Tasks;

namespace EasyTestAnyThing.Async
{
    public class Start
    {
        /// <summary>
        /// Async Await 使用時機
        /// </summary>
        public static void StartMethod() 
        {
            Important();
            NotImportant();
        }

        /// <summary>
        /// 這筆資料很重要,調用方法後馬上要用來做運算.
        /// </summary>
        private static async void Important()
        {
            var startTime = GetDateTimeNow();
            var x = await GetData(1);
            var y = await GetData(2);
            var useDataToDoSomething01 = x + y;
            var z = await GetData(3);
            var useDataToDoSomething02 = useDataToDoSomething01 + z;

            Console.WriteLine("Important");
            Console.WriteLine("取得資料" + useDataToDoSomething02);
            Console.WriteLine("Done Total Using Time = 00:{0:ss} sec", (GetDateTimeNow() - startTime));
        }

        /// <summary>
        /// 這筆資料不太重要,等下要用到在 await 他就好.
        /// </summary>
        private static async void NotImportant()
        {
            var startTime = GetDateTimeNow();
            var x = GetData(1);
            var y = GetData(2);
            var z = GetData(3);
            var data = await x + await y + await z;
            Console.WriteLine("NotImportant");
            Console.WriteLine("取得資料" + data);
            Console.WriteLine("Done Total Using Time = 00:{0} sec", (GetDateTimeNow() - startTime).ToString("ss"));
        }

        private static DateTime GetDateTimeNow() 
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 模擬遠端回傳資料
        /// </summary>
        /// <param name="sec">假設該筆資料回傳時間</param>
        /// <returns>回傳值假設為取得的資料</returns>
        private static async Task<int> GetData(int sec)
        {
            await Task.Delay(sec * 1000);
            return sec;
        }
    }
}