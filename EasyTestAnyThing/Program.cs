using System;

namespace EasyTestAnyThing
{
    public class Program
    {
        private static void Main()
        {
            var fizzBuzzClass = new MSClass.New.MockPage.PageNextBack();
            var x = fizzBuzzClass.NextBack();
            x.ForEach(f => Console.WriteLine(f.VideoName + f.VideoType));
            //WebServer.ServerStart.StartServer();
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
        using xUnit;

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