using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTestAnyThing.MSClass.New.Locker
{
    /*
     * https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/concepts/async/async-return-types
     */
    public class NewLocker
    {
        public decimal SameTimeInsertMoney()
        {
            var tasks = new List<Task>();
            for (int i = 1; i < 10; i++)
            {
                tasks.Add(InsertSomeThing(i));
            }
            Task.WhenAll(tasks);
            return Wallet.GetBalance();
        }

        private Task InsertSomeThing(decimal amount)
        {
            Wallet.InsertBalance(amount);
            Console.WriteLine(
                Thread.CurrentThread.ManagedThreadId +
                ",Now Balance is " +
                Wallet.GetBalance());
           return Task.Delay(1);
        }
    }

    public static class Wallet
    {
        private static object Locker => new object();

        private static decimal _balance;

        public static void InsertBalance(decimal amount)
        {
            lock (Locker)
            {
                _balance += amount;
            }
        }

        public static decimal GetBalance()
        {
            lock (Locker)
            {
                return _balance;
            }
        }
    }
}