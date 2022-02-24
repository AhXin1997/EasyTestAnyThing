using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTestAnyThing.CSharpQueue
{
    public static class Start
    {
        /*
         * Queue 隊列
         *
         * 大致流程 :
         * https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.queue?view=net-6.0
         * https://ithelp.ithome.com.tw/articles/10218902
         */

        /* 情境一
         * 創建一個 RespondWithSleep
         * 執行三個  6 + 1 + 3 s
         * 執行完後才執行下一個總計為 10s
         */

        /* 情境二
         * 面對多位使用者同時操作系統時
         * 依先來先用順序
         * 使用系統功能
         * 使用系統順序長短由個人控制
         * 第一個人使用了6s
         * 第二個人使用了1s
         * 第三個人使用了3s
         */

        //var y =  new ConcurrentQueue<int>();

        public static void StartMethod()
        {
            var qe = new Queue<Task>();
            qe.Enqueue(RespondWithSleep("AhXin", 6));
            qe.Enqueue(RespondWithSleep("Leo", 1));
            qe.Enqueue(RespondWithSleep("Zoe", 3));
            Console.WriteLine($"Now Queue Item Count {qe.Count}");
            QueueFactory(qe, true);
            Console.WriteLine($"Now Queue Item Count {qe.Count}");
        }

        private static Task RespondWithSleep(string user, int sec)
        {
            return new Task(() =>
            {
                Thread.Sleep(sec * 1000);
                Console.WriteLine($"對列 {user},使用了{sec}秒,執行時間為 :" + DateTime.Now.ToString("mm:ss"));
            });
        }

        //已同步方法執行對列
        //已非同步方法執行對列

        /// <summary>
        /// 每跑一次刪一個
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="asyncOrNot"></param>
        private static void QueueFactory(Queue<Task> collection, bool asyncOrNot)
        {
            var oldList = collection.ToList();
            var startTime = DateTime.Now;
            Console.WriteLine("開始時間為 : " + startTime.ToString("mm:ss"));
            while (collection.Any())
            {
                var task = collection.Dequeue();

                Console.WriteLine("Start Working Queue Item : " + oldList.IndexOf(task));
                task.Start();
                if (asyncOrNot)
                {
                    task.GetAwaiter().GetResult();
                }
            }
            var endTime = DateTime.Now;
            Console.WriteLine("結束時間為 : " + startTime.ToString("mm:ss"));
            Console.WriteLine("總耗時為 : " + (startTime - endTime).TotalSeconds);
        }
    }
}