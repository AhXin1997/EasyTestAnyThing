using System;
using EasyTestAnyThing.DependencyInjection.PlugDemo.Interface;

namespace EasyTestAnyThing.DependencyInjection.PlugDemo
{
    public class HairDryer : IHomeAppliance
    {
        public void Connect()
        {
            Console.WriteLine("Now You Can Use " + nameof(HairDryer));
        }
    }
}