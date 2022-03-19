using EasyTestAnyThing.MSClass.New.MonsterAndHeroGame;
using EasyTestAnyThing.MSClass.New.MonsterAndHeroGame.Models;
using EasyTestAnyThing.MSClass.New.MonsterAndHeroGame.Models.Response;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace EasyTestAnyThingTest.MSClass.New.MonsterAndHeroGame
{
    public class MonsterHeroGameTests
    {
        private readonly ITestOutputHelper _output;
        private readonly MonsterHeroGame _target;

        public MonsterHeroGameTests(ITestOutputHelper testOutputHelper)
        {
            _output = testOutputHelper;
            _target = new MonsterHeroGame();
        }

        [Fact]
        public void EveryStepIsRight()
        {
            _target.Start(GivenHero(3), GivenMonster(2))
                .Should()
                .BeEquivalentTo(
                new FightingResponse()
                {
                    FightingRecord = new List<FightingRecord>()
                    {
                        new FightingRecord { AttackBy = "Hero" , DoDamage = 1 , Target = "Monster" , AffterTargetHp = 1 },
                        new FightingRecord { AttackBy = "Monster" , DoDamage = 1 , Target = "Hero" , AffterTargetHp = 2 },
                        new FightingRecord { AttackBy = "Hero" , DoDamage = 1 , Target = "Monster" , AffterTargetHp = 0 }
                    },
                    Winner = "Hero"
                });
        }

        [Fact]
        public void Do_Not_Attack_When_Attacker_Die()
        {
            _target.Start(GivenHero(0), GivenMonster(1))
                .Should()
                .BeEquivalentTo(new FightingResponse()
                {
                    FightingRecord = new List<FightingRecord>(),
                    Winner = "Monster"
                });
        }

        private NewHero GivenHero(int hp)
        {
            return new NewHero("Hero", hp, 1, 1);
        }

        private NewMonster GivenMonster(int hp)
        {
            return new NewMonster("Monster", hp, 1, 1);
        }
    }
}