﻿using System;

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
            StartServer();

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