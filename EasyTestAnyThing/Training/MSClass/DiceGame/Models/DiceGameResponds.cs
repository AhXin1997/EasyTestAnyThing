using System.Collections.Generic;

namespace EasyTestAnyThing.Training.MSClass.DiceGame.Models
{
    public class DiceGameResponds
    {
        public bool IsWin { get; set; }
        public int TotalPoint { get; set; }
        public List<int> DiceBox { get; set; }
    }
}