using DenpendencyInjection.PlugDemo.Interface;
using System;

namespace DenpendencyInjection.PlugDemo
{
    public class HairDryer : IHomeAppliance
    {
        public void Connect()
        {
            Console.WriteLine("Now You Can Use " + nameof(HairDryer));
        }
    }
}