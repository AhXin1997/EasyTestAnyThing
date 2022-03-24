using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTestAnyThing.MSClass.New.Locker
{
    // TODO : 改寫成 Tests , 學習以下兩個Keyword , 探討不同程式之間的如何達成可以達成鎖住的目的
    //volatile
    //[ThreadStatic]
    //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/statements/lock
    public class NewLocker
    {
        public void StartMethod()
        {
            Console.WriteLine("Total Amount Should Be :" + Enumerable.Range(1, 49).Sum());

            MockManyUserSameTimeCallApi();

            Thread.Sleep(3 * 1000);
            Console.WriteLine("Task All Done Amount Is :" + Wallet.GetBalance());
        }

        private void MockManyUserSameTimeCallApi()
        {
            for (int i = 1; i < 50; i++)
            {
                var value = i;
                Task.Run(() => MockInsertMoneyApi(value));
            }
        }

        private Task MockInsertMoneyApi(decimal amount)
        {
            return Task.Run(() =>
                {
                    Wallet.InsertBalance(amount);
                    Console.WriteLine(
                        Thread.CurrentThread.ManagedThreadId +
                        ",Now Blance is " +
                        Wallet.GetBalance());
                });
        }
    }

    public static class Wallet
    {
        private static readonly bool LockerOnOff = true;

        private static readonly object Locker = new object();

        private static decimal Balance;

        public static void InsertBalance(decimal amount)
        {
            if (LockerOnOff)
            {
                lock (Locker)
                {
                    Balance += amount;
                }
            }
            else
            {
                Balance += amount;
            }
        }

        public static decimal GetBalance()
        {
            if (LockerOnOff)
            {
                lock (Locker)
                {
                    return Balance;
                }
            }
            else
            {
                return Balance;
            }
        }
    }
}