using System.Collections.Generic;
using System.Linq;
using EasyTestAnyThing.Training.MSClass.DiceGame;
using FluentAssertions;
using Xunit;

namespace EasyTestAnyThingTest.Training.MSClass.MSClassNew
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
            var intList = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                intList.AddRange(_target.RandDice());
            }
            intList.Distinct().Count().Should().Be(6);
            intList.Distinct().Should()
                .BeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6});
        }
    }
}