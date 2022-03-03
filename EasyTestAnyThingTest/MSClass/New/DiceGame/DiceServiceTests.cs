using EasyTestAnyThing.MSClass.New.DiceGame;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyTestAnyThingTest.MSClass.New.DiceGame
{
    public class DiceServiceTests
    {
        private readonly DiceService _target;

        public DiceServiceTests()
        {
            _target = new DiceService();
        }

        [Fact]
        public void Dice_Count_Equals_3() 
        {
            _target.RandDice().Count.Should().Be(3);
        }

        [Fact]
        public void Dice_Num_Min_And_Max_Is_1_6() 
        {
            var ints = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                ints.AddRange(_target.RandDice());
            }
            ints.Distinct().Count().Should().Be(6);
            ints.Distinct().Should()
                .BeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6});
        }
    }
}