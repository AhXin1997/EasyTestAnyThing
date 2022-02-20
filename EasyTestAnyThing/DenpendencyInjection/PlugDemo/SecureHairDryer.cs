using System;
using System.Collections.Generic;
using System.Linq;
using DenpendencyInjection.PlugDemo.Interface;

namespace DenpendencyInjection.PlugDemo
{
    public class SecureHairDryer : IHomeAppliance
    {
        /*
         * 只有Mom or Dad 可以使用該隻吹風機
         */
        private readonly string _user;
        private  List<string> Identitys => new List<string> { "Mom", "Dad" };

        public SecureHairDryer(string user)
        {
            _user = user;
        }

        public void Connect()
        {
            if (Identitys.FirstOrDefault(w => w == _user) != null)
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