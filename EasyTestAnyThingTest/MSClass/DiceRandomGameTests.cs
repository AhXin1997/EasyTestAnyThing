using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class DiceRandomGameTests
    {
        /*
            2022/01/05
            在 C# 中使用 if-elseif-else 陳述式在程式碼中加入決策邏輯

            如果您擲出的任兩個骰子產生相同的值，即會因為擲出兩倍而得到兩點獎勵。
            如果您擲出的三顆骰子全都產生相同的值，則會因為擲出三倍而得到六點獎勵。
            如果這三顆骰子擲出的總和加上任何獎勵點數為 15 或以上，您就贏得此遊戲。 否則，您就輸了。
        */

        private readonly DiceRandomGame _diceRandomGame;
        private readonly OutputMethod _outputMethod;
        private readonly IDiceMethod _diceMethod;

        public DiceRandomGameTests()
        {
            _diceMethod = Substitute.For<IDiceMethod>();
            _outputMethod = new OutputMethod();
            _diceRandomGame = new DiceRandomGame(_diceMethod, _outputMethod);
        }

        [Fact]
        public void DiceRandomGameMethod_Set_Dice_456_Win_With_No_Bouns()
        {
            //Arrange
            var nums = new List<int> { 4, 5, 6 };
            _diceMethod.Dice().Returns(nums);

            //Act
            _diceRandomGame.Game();

            //Assert
            _outputMethod.GetOutputMessages()
                .Should().BeEquivalentTo(new List<string>()
                {
                    "4,5,6",
                    "TotalPoint:15",
                    "You Win!"
                });
        }

        [Fact]
        public void DiceRandomGameMethod_Set_Dice_123_Lost_With_No_Bouns()
        {
            //Arrange
            var nums = new List<int> { 1, 2, 3 };
            _diceMethod.Dice().Returns(nums);

            //Act
            _diceRandomGame.Game();

            //Assert
            _outputMethod.GetOutputMessages()
                .Should().BeEquivalentTo(new List<string>()
                {
                    "1,2,3",
                    "TotalPoint:6",
                    "Loser!"
                });
        }

        [Fact]
        public void DiceRandomGameMethod_Set_Dice_556_Win_With_Bouns()
        {
            //Arrange
            var nums = new List<int> { 5, 5, 6 };
            _diceMethod.Dice().Returns(nums);
            _diceMethod.GetBonusOrNot(nums).Returns(2);

            //Act
            _diceRandomGame.Game();

            //Assert
            _outputMethod.GetOutputMessages()
                .Should().BeEquivalentTo(new List<string>()
                {
                    "5,5,6",
                    "TotalPoint:18",
                    "You Win!"
                });
        }

        [Fact]
        public void DiceRandomGameMethod_Set_Dice_111_Lose_With_Bouns()
        {
            //Arrange
            var nums = new List<int> { 1, 1, 1 };
            _diceMethod.Dice().Returns(nums);
            _diceMethod.GetBonusOrNot(nums).Returns(3);

            //Act
            _diceRandomGame.Game();

            //Assert
            _outputMethod.GetOutputMessages()
                .Should().BeEquivalentTo(new List<string>()
                {
                    "1,1,1",
                    "TotalPoint:6",
                    "Loser!"
                });
        }
    }

    public class DiceMethodTests
    {
        private DiceMethod _diceMethod;

        public DiceMethodTests()
        {
            _diceMethod = new DiceMethod();
        }

        [Fact]
        public void GetBonusOrNot_NopSame_GetPoint_0()
        {
            var nums = new List<int> { 1, 2, 3 };
            _diceMethod.GetBonusOrNot(nums).Should().Be(0);
        }

        [Fact]
        public void GetBonusOrNot_TwoSame_GetPoint_2()
        {
            var nums = new List<int> { 1, 1, 2 };
            _diceMethod.GetBonusOrNot(nums).Should().Be(2);
        }

        [Fact]
        public void GetBonusOrNot_ThreeSame_GetPoint_3()
        {
            var nums = new List<int> { 1, 1, 1 };
            _diceMethod.GetBonusOrNot(nums).Should().Be(3);
        }

        [Fact]
        public void Dice_Count_Should_be_3()
        {
            _diceMethod.SetDice(3, 1, 6);
            _diceMethod.Dice().Count.Should().Be(3);
        }

        [Fact]
        public void Dice_Count_Should_be_Range1_6()
        {
            //Arrange
            int diceMin = 1;
            int diceMax = 6;
            var diceMethod = new DiceMethod();
            diceMethod.SetDice(10000, diceMin, diceMax);

            //Act
            var actual = diceMethod.Dice();

            //Assert
            actual.Distinct().OrderBy(s => s)
                .Should()
                .BeEquivalentTo(new List<int> { 1, 2, 3, 4, 5, 6 });
        }
    }
}