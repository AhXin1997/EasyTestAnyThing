using EasyTestAnyThing.MSClass.New.Locker;
using System;
using System.Threading.Tasks;

namespace EasyTestAnyThing
{
    public class Program
    {
        private static void Main()
        {
            var x = new NewLocker();
            x.SameTimeInserSomeThing();
            Console.WriteLine(Wallet.Blance);

            var shouldBe = 0;
            for (int i = 1; i < 10; i++)
            {
                shouldBe += i;
            }
            Console.WriteLine(shouldBe);


            //Tool
            //var tool = new EasyOutputMessage();
            //tool.EasyOutputMessageMethod();

            Console.ReadKey();
        }

        /* TODO_List
         * Add Thread Safe C# Example
         * Learn How to use Fun Action
         * Flurl 套件熟悉(串Url)
         *
         * [✓] Console 導入 Mvc架構 可由 PostMan 打入Api
         * Add Filter      Example
         *
         * Try Add Db
         * Add Repository  Example
         * Mapping
         *     one to one
         *     one to many
         *     many to many
         *
         *
         */
    }
}