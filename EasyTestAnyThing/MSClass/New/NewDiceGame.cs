using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New
{
    /*
        2022/03/01
        在 C# 中使用 if-elseif-else 陳述式在程式碼中加入決策邏輯

        如果您擲出的任兩個骰子產生相同的值，即會因為擲出兩倍而得到兩點獎勵。
        如果您擲出的三顆骰子全都產生相同的值，則會因為擲出三倍而得到六點獎勵。
        如果這三顆骰子擲出的總和加上任何獎勵點數為 15 或以上，您就贏得此遊戲。 否則，您就輸了。
    */

    public class NewDiceGame
    {
        public static void Start()
        {
            new NewDiceGame(new GameLogic(), new DiceFactory(), new MessageCenter()).Game();
        }

        private readonly IGameLogic _gameLogic;
        private readonly IDiceFactory _diceFactory;
        private readonly IMessageCenter _messageCenter;

        public NewDiceGame(IGameLogic gameLogic, IDiceFactory diceFactory, IMessageCenter messageCenter)
        {
            _gameLogic = gameLogic;
            _diceFactory = diceFactory;
            _messageCenter = messageCenter;
        }

        public void Game()
        {
            var diceBox = _diceFactory.RandDice();

            var totalPoint = _gameLogic.SumDiceAndGivePoint(diceBox);

            var message = _gameLogic.WinOrLose(totalPoint);

            _messageCenter.SendMessage(message);
        }
    }

    public class MessageCenter : IMessageCenter
    {
        public void SendMessage(string str)
        {
            Console.WriteLine(str);
        }
    }

    public interface IMessageCenter
    {
        void SendMessage(string str);
    }

    public class GameLogic : IGameLogic
    {
        public int SumDiceAndGivePoint(List<int> diceBox)
        {
            if (diceBox.Distinct().Count() == 2)
            {
                return diceBox.Sum() + 2;
            }
            if (diceBox.Distinct().Count() == 1)
            {
                return diceBox.Sum() + 6;
            }
            return diceBox.Sum();
        }

        public string WinOrLose(int totalPoint)
        {
            if (totalPoint >= 15)
            {
                return string.Format("You Win, TotalPoint : {0}", totalPoint);
            }
            else
            {
                return string.Format("You Lose, TotalPoint : {0}", totalPoint);
            }
        }
    }

    public interface IGameLogic
    {
        int SumDiceAndGivePoint(List<int> diceBox);

        string WinOrLose(int totalPoint);
    }

    public class DiceFactory : IDiceFactory
    {
        private readonly Random _rand;

        public DiceFactory()
        {
            _rand = new Random(Guid.NewGuid().GetHashCode());
        }

        public List<int> RandDice()
        {
            var diceBox = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                diceBox.Add(_rand.Next(1, 7));
            }
            return diceBox;
        }
    }

    public interface IDiceFactory
    {
        List<int> RandDice();
    }
}