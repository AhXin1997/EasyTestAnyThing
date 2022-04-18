using System.Collections.Generic;
using EasyTestAnyThing.MSClassNew.DiceGame;
using EasyTestAnyThing.MSClassNew.DiceGame.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace EasyTestAnyThingTest.MSClassNew
{
    public class DiceRandomGameTests
    {
        private readonly IDiceService _diceService;
        private readonly NewDiceGame _target;

        public DiceRandomGameTests()
        {
            _diceService = Substitute.For<IDiceService>();
            _target = new NewDiceGame(_diceService);
        }

        [Fact]
        public void Dice_Not_Same_And_Lose()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 5, 3 });

            var action = _target.Game();

            action.Should().BeEquivalentTo(new DiceGameResponds()
            {
                DiceBox = new List<int> { 6, 5, 3 },
                IsWin = false,
                TotalPoint = 14
            }
            );
        }

        [Fact]
        public void Dice_Two_Same_And_Lose()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 1, 1 });

            var action = _target.Game();

            action.Should().BeEquivalentTo(new DiceGameResponds()
            {
                DiceBox = new List<int> { 6, 1, 1 },
                IsWin = false,
                TotalPoint = 10
            }
            );
        }

        [Fact]
        public void Dice_All_Same_And_Lose()
        {
            _diceService.RandDice().Returns(new List<int> { 1, 1, 1 });

            var action = _target.Game();

            action.Should().BeEquivalentTo(new DiceGameResponds()
            {
                DiceBox = new List<int> { 1, 1, 1 },
                IsWin = false,
                TotalPoint = 9
            }
            );
        }

        [Fact]
        public void Dice_Not_Same_And_Win()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 5, 4 });

            var action = _target.Game();

            action.Should().BeEquivalentTo(new DiceGameResponds()
            {
                DiceBox = new List<int> { 6, 5, 4 },
                IsWin = true,
                TotalPoint = 15
            }
            );
        }

        [Fact]
        public void Dice_Two_Same_And_Win()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 5, 5 });

            var action = _target.Game();

            action.Should().BeEquivalentTo(new DiceGameResponds()
            {
                DiceBox = new List<int> { 6, 5, 5 },
                IsWin = true,
                TotalPoint = 18
            }
            );
        }

        [Fact]
        public void Dice_All_Same_And_Win()
        {
            _diceService.RandDice().Returns(new List<int> { 6, 6, 6 });

            var action = _target.Game();

            action.Should().BeEquivalentTo(new DiceGameResponds()
            {
                DiceBox = new List<int> { 6, 6, 6 },
                IsWin = true,
                TotalPoint = 24
            }
            );
        }
    }
}