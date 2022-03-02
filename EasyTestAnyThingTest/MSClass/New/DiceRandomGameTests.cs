using EasyTestAnyThing.MSClass.New;
using NSubstitute;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace EasyTestAnyThingTest.MSClass.New
{
    public class DiceRandomGameTests
    {
        private readonly IGameLogic _gameLogic;
        private readonly IDiceFactory _diceFactory;
        private readonly IMessageCenter _messageCenter;
        private readonly NewDiceGame _target;

        public DiceRandomGameTests()
        {
            _gameLogic = Substitute.For<IGameLogic>();
            _diceFactory = Substitute.For<IDiceFactory>();
            _messageCenter = Substitute.For<IMessageCenter>();
            _target = new NewDiceGame(_gameLogic, _diceFactory, _messageCenter);
        }

        [Fact]
        public void Dice_Not_Same_And_Lose()
        {
            _target.Game();

            _diceFactory.Received().RandDice();
            _gameLogic.Received().WinOrLose(Arg.Any<int>());
            _gameLogic.Received().SumDiceAndGivePoint(Arg.Any<List<int>>());
            _messageCenter.Received().SendMessage(Arg.Any<string>());
        }
    }

    public class GameLogicTests
    {
        private readonly GameLogic _target;

        public GameLogicTests()
        {
            _target = new GameLogic();
        }

        [Fact]
        public void 三個不同數值_沒有獎勵點數()
        {
            var diceBox = new List<int>() { 1, 2, 3 };

            var action = _target.SumDiceAndGivePoint(diceBox);

            action.Should().Be(6);
        }

        [Fact] public void 兩個相同數值_獎勵點數為2()
        {
            var diceBox = new List<int>() { 2, 2, 3 };

            var action = _target.SumDiceAndGivePoint(diceBox);

            action.Should().Be(9);
        }

        [Fact]
        public void 三個相同數值_獎勵點數為6()
        {
            var diceBox = new List<int>() { 2, 2, 2 };

            var action = _target.SumDiceAndGivePoint(diceBox);

            action.Should().Be(12);
        }

        [Fact]
        public void LoseWay()
        {
            var action = _target.WinOrLose(10);

            action.Should().Be("You Lose, TotalPoint : 10");
        }

        [Fact]
        public void WinWay()
        {
            var action = _target.WinOrLose(15);

            action.Should().Be("You Win, TotalPoint : 15");
        }
    }
}