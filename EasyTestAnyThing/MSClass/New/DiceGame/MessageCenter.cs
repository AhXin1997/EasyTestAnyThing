using System;
using System.Collections.Generic;

namespace EasyTestAnyThing.MSClass.New.DiceGame
{
    public class MessageCenter : IMessageCenter
    {
        public void SendMessage(string str)
        {
            Console.WriteLine(str);
        }

        public void SendMessage(List<int> diceBox)
        {
            string str = string.Empty;
            diceBox.ForEach(f => str += $"{f} ");
            Console.WriteLine("Dice Box : " + str);
        }
    }

    public interface IMessageCenter
    {
        void SendMessage(string str);

        void SendMessage(List<int> diceBox);
    }
}