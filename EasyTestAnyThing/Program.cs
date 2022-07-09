using EasyTestAnyThing.Tool;
using EasyTestAnyThing.Tool.Enum;
using System;
using EasyTestAnyThing.WebServer;

namespace EasyTestAnyThing
{
    public class Program
    {
        private class Name
        {
        }

        private static void Main()
        {
            //[Tool]
            typeof(Name).EasyOutputMessageMethod(EasyOutputMessageMethod.ToMultilingualKeysName);

            //[WebServer]
            ServerStart.Server(false);

            Console.ReadKey();
        }

        /* TODO_List
         * Add Thread Safe C# Example
         * Learn How to use Fun Action
         * Flurl 套件熟悉(串Url)
         * Autofac
         * Mediator
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