using System;
using System.Collections.Generic;
using System.Linq;
using EasyTestAnyThing.Training.DependencyInjection.PlugDemo.Interface;

namespace EasyTestAnyThing.Training.DependencyInjection.PlugDemo
{
    public class SecureHairDryer : IHomeAppliance
    {
        /*
         * 只有Mom or Dad 可以使用該隻吹風機
         */
        private readonly string _user;
        private IEnumerable<string> Identities => new List<string> { "Mom", "Dad" };

        public SecureHairDryer(string user)
        {
            _user = user;
        }

        public void Connect()
        {
            if (Identities.FirstOrDefault(w => w == _user) != null)
            {
                Console.WriteLine("Now " + _user + " Can Use " + nameof(SecureHairDryer));
            }
            else
            {
                Console.WriteLine(_user + " Can't Use");
            }
        }
    }
}