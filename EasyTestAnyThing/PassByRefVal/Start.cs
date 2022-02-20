using System;

namespace EasyTestAnyThing.PassByRefVal
{
    public static class Start
    {
        public static void StartMethod()
        {
            Console.WriteLine(nameof(PassingValByVal));
            PassingValByVal.Start();
            Console.WriteLine("\n");
            Console.WriteLine(nameof(PassingValByRef));
            PassingValByRef.Start();
        }
    }
}