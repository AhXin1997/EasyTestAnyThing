using System;
using System.Collections.Generic;

namespace EasyTestAnyThing.MSClass.New.DiceGame
{
    public class MessageCenter : IMessageCenter
    {
        public void SendMessage(int totalPoint, bool winOrLose)
        {
            Console.WriteLine(winOrLose ?
                $"You Win, TotalPoint : {totalPoint}" :
                $"You Lose, TotalPoint : {totalPoint}");
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
        void SendMessage(int totalPoint, bool winOrLose);

        void SendMessage(List<int> diceBox);
    }
}