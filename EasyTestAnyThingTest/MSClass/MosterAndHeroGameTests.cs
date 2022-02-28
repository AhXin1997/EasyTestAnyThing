using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace EasyTestAnyThing.MSClass.Tests
{
    public class MosterAndHeroGameTests
    {
        [Fact]
        public void MosterAndHeroGame_Logic_Right()
        {
            var hero = new Hero("Hero", 3, 1, 1);
            var monster = new Monster("Monster", 2, 1, 1);
            var target = new MosterAndHeroGame(hero, monster);

            var actual = target.Run();

            actual.Log.Should().BeEquivalentTo(new List<MonsterAndHeroGameFightLog>
            {
             new MonsterAndHeroGameFightLog{Attacker = "Hero" , Target = "Monster" , LostHp = 1 , TargetHp = 1 },
             new MonsterAndHeroGameFightLog{Attacker = "Monster" ,Target = "Hero" , LostHp = 1 , TargetHp = 2 },
             new MonsterAndHeroGameFightLog{Attacker = "Hero" ,Target = "Monster" , LostHp = 1 , TargetHp = 0 }
            });
        }

        [Fact]
        public void MosterAndHeroGame_Winner_Right()
        {
            var hero = new Hero("Hero", 3, 1, 1);
            var monster = new Monster("Monster", 2, 1, 1);
            var target = new MosterAndHeroGame(hero, monster);

            var actual = target.Run();

            actual.Winner.Should().Be("Hero is Winner!");
        }
    }
}