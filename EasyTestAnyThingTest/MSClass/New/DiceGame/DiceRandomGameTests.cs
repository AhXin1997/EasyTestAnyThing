using EasyTestAnyThing.MSClass.New.DiceGame;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace EasyTestAnyThingTest.MSClass.New.DiceGame
{
    public class DiceRandomGameTests
    {
        private readonly IDiceService _diceService;
        private readonly IMessageCenter _messageCenter;
        private readonly NewDiceGame _target;

        public DiceRandomGameTests()
        {
            _diceService = Substitute.For<IDiceService>();
            _messageCenter = Substitute.For<IMessageCenter>();
            _target = new NewDiceGame(_diceService, _messageCenter);
        }

        [Fact]
        public void Dice_Not_Same_And_Lose()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 5, 3 });

            _target.Game();

            _messageCenter.Received().SendMessage(Arg.Is<List<int>>(r => r[0] == 6 && r[1] == 5 && r[2] == 3));
            _messageCenter.Received().SendMessage(Arg.Is<string>(r => r == "You Lose, TotalPoint : 14"));
        }

        [Fact]
        public void Dice_Two_Same_And_Lose()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 1, 1 });

            _target.Game();

            _messageCenter.Received().SendMessage(Arg.Is<List<int>>(r => r[0] == 6 && r[1] == 1 && r[2] == 1));
            _messageCenter.Received().SendMessage(Arg.Is<string>(r => r == "You Lose, TotalPoint : 10"));
        }

        [Fact]
        public void Dice_All_Same_And_Lose()
        {
            _diceService.RandDice().Returns(new List<int> { 1, 1, 1 });

            _target.Game();

            _messageCenter.Received().SendMessage(Arg.Is<List<int>>(r => r[0] == 1 && r[1] == 1 && r[2] == 1));
            _messageCenter.Received().SendMessage(Arg.Is<string>(r => r == "You Lose, TotalPoint : 9"));
        }

        [Fact]
        public void Dice_Not_Same_And_Win()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 5, 4 });

            _target.Game();

            _messageCenter.Received().SendMessage(Arg.Is<List<int>>(r => r[0] == 6 && r[1] == 5 && r[2] == 4));
            _messageCenter.Received().SendMessage(Arg.Is<string>(r => r == "You Win, TotalPoint : 15"));
        }

        [Fact]
        public void Dice_Two_Same_And_Win()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 5, 5 });

            _target.Game();

            _messageCenter.Received().SendMessage(Arg.Is<List<int>>(r => r[0] == 6 && r[1] == 5 && r[2] == 5));
            _messageCenter.Received().SendMessage(Arg.Is<string>(r => r == "You Win, TotalPoint : 18"));
        }

        [Fact]
        public void Dice_All_Same_And_Win()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 6, 6 });

            _target.Game();

            _messageCenter.Received().SendMessage(Arg.Is<List<int>>(r => r[0] == 6 && r[1] == 6 && r[2] == 6));
            _messageCenter.Received().SendMessage(Arg.Is<string>(r => r == "You Win, TotalPoint : 24"));
        }
    }
}