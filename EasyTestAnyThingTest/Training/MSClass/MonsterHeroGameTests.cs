using System.Collections.Generic;
using EasyTestAnyThing.Training.MSClass.MonsterAndHeroGame;
using EasyTestAnyThing.Training.MSClass.MonsterAndHeroGame.Models;
using EasyTestAnyThing.Training.MSClass.MonsterAndHeroGame.Models.Response;
using FluentAssertions;
using Xunit;

namespace EasyTestAnyThingTest.Training.MSClass
{
    public class MonsterHeroGameTests
    {
        private readonly NewMonsterAndHeroGame _target;

        public MonsterHeroGameTests()
        {
            _target = new NewMonsterAndHeroGame();
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