using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EasyTestAnyThingTest.Training.CSharpQueue
{
    /// <summary>
    /// Queue 隊列.
    /// (本質為 : 先進先出(FIFO),集合中處理完的物件可移除.)
    /// </summary>
    public class QueueTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public QueueTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        /* 情境一
         * 執行三個 Function => 每個 Function 耗時 1s + 2s + 3s
         * 執行完後才執行下一個總計為 6s
         * 耗時就skip
         */
        [Fact(Skip = "skip")]
        public void Solution01_同步()
        {
            _outputHelper.WriteLine("【Solution01_同步】");
            AddQueueAndDequeue(false);
        }

        private void AddQueueAndDequeue(bool isAsync)
        {
            var queue = new Queue<Task<Action>>();
            queue.Enqueue(TaskAction("AhXin", 1));
            queue.Enqueue(TaskAction("Leo", 2));
            queue.Enqueue(TaskAction("Zoe", 3));
            QueueProductionLine(queue);
        }

        private Task<Action> TaskAction(string user, int sec)
        {
            var message = $"對列 {user},使用了{sec}秒, 執行結束時間為 : " + DateTime.Now.ToString("mm:ss");
            Thread.Sleep(sec * 1000);
            return Task.FromResult<Action>(() =>
            {
                _outputHelper.WriteLine(message);
            });
        }

        /// <summary>
        /// 讀取一個 Task 則刪除一個 Task.
        /// </summary>
        /// <param name="queue">對列物件</param>
        private void QueueProductionLine(Queue<Task<Action>> queue)
        {
            while (queue.Any())
            {
                var task = queue.Dequeue();
                task.GetAwaiter().GetResult().Invoke();
            }
        }
    }
}