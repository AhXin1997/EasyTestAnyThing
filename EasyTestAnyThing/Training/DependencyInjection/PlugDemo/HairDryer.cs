using System;
using EasyTestAnyThing.Training.DependencyInjection.PlugDemo.Interface;

namespace EasyTestAnyThing.Training.DependencyInjection.PlugDemo
{
    public class HairDryer : IHomeAppliance
    {
        public void Connect()
        {
            Console.WriteLine("Now You Can Use " + nameof(HairDryer));
        }
    }
}