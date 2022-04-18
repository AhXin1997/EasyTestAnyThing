﻿using System.Threading;

namespace EasyTestAnyThing.MSClassNew.Locker
{
    // TODO : 改寫成 Tests , 學習以下兩個Keyword , 探討不同程式之間的如何達成可以達成鎖住的目的
    //volatile
    //[ThreadStatic]
    //https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/statements/lock

    public static class Wallet
    {
        public static bool LockerOnOff { get; set; }

        private static readonly object Locker = new object();

        private static decimal Balance;

        public static string InsertBalance(decimal amount)
        {
            //For Test, So Return String.
            if (LockerOnOff)
            {
                lock (Locker)
                {
                    return $"[Thread : {Thread.CurrentThread.ManagedThreadId}] " +
                           $"{Balance} + {amount} = {Balance += amount}";
                }
            }
            else
            {
                return $"[Thread : {Thread.CurrentThread.ManagedThreadId}] " +
                       $"{Balance} + {amount} = {Balance += amount}";
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