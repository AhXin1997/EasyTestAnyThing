using System;
using System.Runtime.CompilerServices;

namespace EasyTestAnyThing
{
    public class Program
    {
        private static void Main()
        {
            var x = new EasyTestAnyThing.ForeachDoNotNewObject.WhatNotNewObject();
            x.Start(true);

            Console.ReadKey();
        }

        /* TODO_List
        Add Thread Safe C# Example
        Learn How to use Fun Action
        Flurl 套件熟悉(串Url)

        [✓] Console 導入 Mvc架構 可由 PostMan 打入Api
        Add Filter      Example

        Try Add Db
        Add Repository  Example
        Mapping
            one to one
            one to many
            many to many

         */
    }
}