using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass
{
    public class OutputMethod
    {
        private List<string> outputMessageList = new List<string>();

        internal void AddMessage(string msg)
        {
            outputMessageList.Add(msg);
        }

        internal void Output()
        {
            outputMessageList.ForEach(msg => Console.WriteLine(msg));
        }

        public List<string> GetOutputMessages()
        {
            return outputMessageList;
        }
    }

    public class DiceRandomGame
    {
        /*
            2022/01/05
            在 C# 中使用 if-elseif-else 陳述式在程式碼中加入決策邏輯

            如果您擲出的任兩個骰子產生相同的值，即會因為擲出兩倍而得到兩點獎勵。
            如果您擲出的三顆骰子全都產生相同的值，則會因為擲出三倍而得到六點獎勵。
            如果這三顆骰子擲出的總和加上任何獎勵點數為 15 或以上，您就贏得此遊戲。 否則，您就輸了。
        */
        protected int _totalPoint;
        protected IDiceMethod _diceMethod;
        protected string _log;
        private OutputMethod _outputMethod;

        public DiceRandomGame(IDiceMethod diceMethod, OutputMethod outputMethod)
        {
            _diceMethod = diceMethod;
            _outputMethod = outputMethod ?? new OutputMethod();
        }

        public void Game()
        {
            _totalPoint = 0;
            _diceMethod.SetDice(3, 1, 6);
            var diceOutput = _diceMethod.Dice();

            _totalPoint += diceOutput.Sum();
            _totalPoint += _diceMethod.GetBonusOrNot(diceOutput);

            _outputMethod.AddMessage(string.Join(",", diceOutput));
            _outputMethod.AddMessage($"TotalPoint:{_totalPoint}");
            _outputMethod.AddMessage((_totalPoint >= 15 ? "You Win!" : "Loser!"));
            _outputMethod.Output();
        }
    }

    public class DiceMethod : IDiceMethod
    {
        private int _diceRollCount;
        private int _diceMin;
        private int _diceMax;

        public int GetBonusOrNot(List<int> diceOutput)
        {
            var SameCount = diceOutput.GroupBy(g => g).Count();
            if (SameCount == 2) return 2;
            if (SameCount == 1) return 3;
            return 0;
        }

        public void SetDice(int rollCount, int min, int max)
        {
            _diceRollCount = rollCount;
            _diceMin = min;
            _diceMax = max;
        }

        public List<int> Dice()
        {
            var dice = new Random(Guid.NewGuid().GetHashCode());
            var diceOutput = new List<int>();
            for (int i = 0; i < _diceRollCount; i++)
            {
                diceOutput.Add(dice.Next(_diceMin, _diceMax +1 ));
            }
            return diceOutput;
        }
    }

    public interface IDiceMethod
    {
        int GetBonusOrNot(List<int> diceOutput);

        List<int> Dice();

        void SetDice(int rollCount, int min, int max);
    }
}