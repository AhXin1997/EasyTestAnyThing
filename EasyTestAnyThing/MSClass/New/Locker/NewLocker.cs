using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EasyTestAnyThing.MSClass.New.Locker
{
    public class NewLocker
    {
        private static object _locker => new object();

        public void SameTimeInserSomeThing()
        {
            for (int i = 1; i < 10; i++)
            {
                Task.Run(() => InserSomeThing(i));
            }
        }

        private void InserSomeThing(decimal amount)
        {
            lock (_locker)
            {
                Wallet.Blance += amount;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ",Now Blance is " + Wallet.Blance);
            }
        }
    }

    public static class Wallet
    {
        public static decimal Blance { get; set; }
    }
}