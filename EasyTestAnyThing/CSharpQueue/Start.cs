using System;
using System.Collections;
using System.Threading.Tasks;

namespace EasyTestAnyThing.CSharpQueue
{
    public static class Start
    {
        /*
         * Queue 隊列
         * 
         * 大致流程 :
         * 希望可達到
         * 把Task丟入隊列內
         * 變成一個一個Task跑
         * https://docs.microsoft.com/zh-tw/dotnet/api/system.collections.queue?view=net-6.0
         */

        public static void StartMethod()
        {
            Queue qe = new Queue();
            //qe.Enqueue(DisplayString_Task("Run_01"));
            //qe.Enqueue(DisplayString_Task("Run_02"));
            //qe.Enqueue(DisplayString_Task("Run_03")); 

            qe.Enqueue("Run_01");
            qe.Enqueue("Run_02");
            qe.Enqueue("Run_03");

            Console.WriteLine(string.Format("Now Queue Item Count {0}", qe.Count));
            QueueFactory(qe);
            Console.WriteLine(string.Format("Now Queue Item Count {0}", qe.Count));
        }

        /// <summary>
        /// 非同步方法 順序有問題
        /// 執行 QueueFactory() 時
        /// 每個都用 Task 打出去 造成沒排隊效果
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static Task DisplayString_Task(string str)
        {
            return Task.Run(() => Console.WriteLine(str)); 
        }

        /// <summary>
        /// 每跑一次就刪一個
        /// </summary>
        /// <param name="collection"></param>
        private static void QueueFactory(Queue collection)
        {
            foreach (var item in collection.Clone() as Queue)
            {
                Console.WriteLine(collection.Dequeue());
            }
        }
    }
}