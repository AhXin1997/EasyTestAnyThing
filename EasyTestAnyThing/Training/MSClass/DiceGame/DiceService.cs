using System;
using System.Collections.Generic;

namespace EasyTestAnyThing.Training.MSClass.DiceGame
{
    public class DiceService : IDiceService
    {
        private readonly Random _rand;

        public DiceService()
        {
            _rand = new Random(Guid.NewGuid().GetHashCode());
        }

        public List<int> RandDice()
        {
            var diceBox = new List<int>();
            for (var i = 0; i < 3; i++)
            {
                diceBox.Add(_rand.Next(1, 7));
            }
            return diceBox;
        }
    }

    public interface IDiceService
    {
        List<int> RandDice();
    }
}