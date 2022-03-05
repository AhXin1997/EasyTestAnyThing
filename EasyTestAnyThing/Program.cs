using System;

namespace EasyTestAnyThing
{
    public class Program
    {
        private static void Main()
        {
            //WebServer.ServerStart.StartServer();
            var x = new MSClass.New.FizzBizz.MarkFizzBuzz();
            x.StartMethod();
            Console.ReadKey();
        }

        /* TODO_List
        Add Thread Safe C# Example
        Learn How to use Fun Action
        Flurl 套件熟悉(串Url)

        Add UnitTestsThing > Program.cs
        Add UnitTestsThing > MSClass > .cs File
        Add UnitTestsThing > UnitTestThingTests > MSClass > .cs File

        using FluentAssertions;
        using NSubstitute;
        using Xunit;

        [✓] Consolo 導入 Mvc架構 可由 PostMan 打入Api
        Add Fliter      Example

        Try Add Db
        Add Repository  Example
        Mapping
            one to one
            one to many
            many to many

         */
    }
}