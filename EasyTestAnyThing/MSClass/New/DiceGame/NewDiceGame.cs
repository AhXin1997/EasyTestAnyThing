using EasyTestAnyThing.MSClass.New.DiceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass.New.DiceGame
{
    public class NewDiceGame
    {
        /// <summary>
        ///此 StartMethod 模擬 Front-End 使用情況。
        ///骰子遊戲，
        ///如果您擲出的任兩個骰子產生相同的值，即會因為擲出兩倍而得到兩點獎勵。
        ///如果您擲出的三顆骰子全都產生相同的值，則會因為擲出三倍而得到六點獎勵。
        ///如果這三顆骰子擲出的總和加上任何獎勵點數為 15 或以上，您就贏得此遊戲。 否則，您就輸了。
        /// </summary>
        public static void StartMethod()
        {
            var gameResponds = new NewDiceGame(new DiceService()).Game();

            Console.WriteLine(gameResponds.IsWin ?
                $"You Win, TotalPoint : {gameResponds.TotalPoint}" :
                $"You Lose, TotalPoint : {gameResponds.TotalPoint}");

            string str = string.Empty;
            gameResponds.DiceBox.ForEach(f => str += $"{f} ");
            Console.WriteLine("Dice Box : " + str);
        }

        private readonly IDiceService _diceService;
        private readonly int _winnerStandard = 15;
        private readonly int _threeSameDiceGetPoint = 6;
        private readonly int _twoSameDiceGetPoint = 2;

        public NewDiceGame(IDiceService diceService)
        {
            _diceService = diceService;
        }

        public DiceGameResponds Game()
        {
            var diceBox = _diceService.RandDice();

            var totalPoint = SumDiceAndGivePoint(diceBox);

            var winOrLose = WinOrLose(totalPoint);

            return new DiceGameResponds
            {
                DiceBox = diceBox,
                TotalPoint = totalPoint,
                IsWin = winOrLose
            };
        }

        private int SumDiceAndGivePoint(List<int> diceBox)
        {
            switch (diceBox.Distinct().Count())
            {
                case 2:
                    return diceBox.Sum() + _twoSameDiceGetPoint;

                case 1:
                    return diceBox.Sum() + _threeSameDiceGetPoint;

                default:
                    return diceBox.Sum();
            }
        }

        private bool WinOrLose(int totalPoint)
        {
            return totalPoint >= _winnerStandard;
        }
    }
}