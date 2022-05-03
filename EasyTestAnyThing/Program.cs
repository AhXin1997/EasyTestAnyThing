using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing
{
    public class Program
    {
        private static void Main()
        {
            //Tool
            //var tool = new EasyOutputMessage();
            //tool.EasyOutputMessageMethod();

            //WebServer
            //StartServer();

            var parameters = new Dictionary<string, string>()
            {
                {"trade_no","1"},
                {"amount","2"},
                {"request_amount","3"},
                {"out_trade_no","4"},
                {"state","5"},
                {"sign","6"},
            };

            var x = parameters
                .Where(r => r.Key != "sign" && r.Key != "realOrderNo")
                .OrderBy(r => r.Key, StringComparer.Ordinal);
                
            x.ToList().ForEach(f => Console.Write($"{f.Key} + {f.Value}"));
            Console.WriteLine();
            x.Select(r => $"{r.Key}={r.Value}").ToList().ForEach(Console.Write);
            Console.WriteLine();
            x.Select(r => $"{r.Key}={r.Value}").Aggregate((a, b) => $"{a}&{b}").ToList().ForEach(Console.Write);
            Console.WriteLine();

            var compare = string.Compare("A", "a", true);

            Console.WriteLine(compare);

            Console.ReadKey();
        }

        private static void StartServer() 
        {
            WebServer.ServerStart.StartServer();
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