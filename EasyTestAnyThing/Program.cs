using System;
using System.Collections.Generic;
using System.Linq;
using EasyTestAnyThing.Tool;
using EasyTestAnyThing.Tool.Enum;

namespace EasyTestAnyThing
{
    public class Program
    {
        class Name
        {
        }

        private static void Main()
        {
            ////[Tool]
            //EasyOutputMessage.EasyOutputMessageMethod(
            //    typeof(Name),
            //    EasyOutputMessageMethod.ToMultilingualKeysName);

            ////[WebServer]
            //WebServer.ServerStart.StartServer();

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