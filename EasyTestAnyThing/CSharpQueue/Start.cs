using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTestAnyThing.CSharpQueue
{
    public static class Start
    {
        /// <summary>
        /// Queue 隊列.
        /// (本質為 : 先進先出(FIFO),集合中處理完的物件可移除.)
        /// </summary>
        public static void StartMethod()
        {
            /* 情境一
             * 執行三個 Funtion => 每個 Funtion 耗時 6s + 1s + 3s
             * 執行完後才執行下一個總計為 10s
             * 可能應用 : 要對 DbTable 進行寫入與讀取操作
             */
            Console.WriteLine("【Solution01_同步】");
            AddQueueAndDequeue(true);

            /* 情境二
             * 執行三個 Funtion => 每個 Funtion 耗時 6s + 1s + 3s
             * 執行總時間總計為 6s
             *
             * 可能應用 : 面對多位使用者同時操作系統,依先來先用順序,提高使用者體驗
             */
            Console.WriteLine("【Solution02_非同步】");
            AddQueueAndDequeue(false);
        }

        private static void AddQueueAndDequeue(bool notAsync)
        {
            var qe = new Queue<Task>();
            qe.Enqueue(Respond("AhXin", 6));
            qe.Enqueue(Respond("Leo", 1));
            qe.Enqueue(Respond("Zoe", 3));
            QueueFactory(qe, notAsync);
        }

        private static Task Respond(string user, int sec)
        {
            return new Task(() =>
            {
                var startTime = DateTime.Now;
                Thread.Sleep(sec * 1000);
                var endTime = DateTime.Now;
                Console.WriteLine($"對列 {user},使用了{sec}秒, 執行結束時間為 : "
                    + DateTime.Now.ToString("mm:ss"));
            });
        }

        /// <summary>
        /// 讀取一個 Task 則刪除一個 Task.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="notAsync">設定為 Ture 則為同步狀態</param>
        private static void QueueFactory(Queue<Task> collection, bool notAsync)
        {
            var oldList = collection.ToList();
            while (collection.Any())
            {
                var task = collection.Dequeue();

                Console.WriteLine("Start Working Queue Item : " + oldList.IndexOf(task));
                task.Start();
                if (notAsync)
                {
                    task.GetAwaiter().GetResult();
                }
            }
        }
    }
}