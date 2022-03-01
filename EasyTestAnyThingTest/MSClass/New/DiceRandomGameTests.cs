using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyTestAnyThing.MSClass.New.Tests
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
            _diceFactory.RandDice().Returns(new List<int> { 5, 4, 3 });
            _gameLogic.WinOrLose(Arg.Any<int>()).Returns("You Lose, TotalPoint : 12");

            _target.Game();

            _messageCenter.Received().SendMessage(Arg.Is<string>(i => i == "You Lose, TotalPoint : 12"));
        }
    }
}