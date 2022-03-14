using System;

namespace EasyTestAnyThing
{
    public class Program
    {
        private static void Main()
        {
            //var list = new List<string>();
            //var type = typeof(Rich88BetRecord);
            //foreach (var index in type.GetProperties())
            //{
            //    list.Add($"public {index.PropertyType.ToString().Replace("System.","").ToLower()} {index.Name} " + "{get; set;}");
            //}
            //list.ForEach(f => Console.WriteLine(f));
            //Console.ReadKey();

            var x = new DoNotNewObjectInLoop.WhyNotNewObjectInLoop();
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