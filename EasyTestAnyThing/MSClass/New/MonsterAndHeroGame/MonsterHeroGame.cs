using EasyTestAnyThing.MSClass.New.MonsterAndHeroGame.Models;
using EasyTestAnyThing.MSClass.New.MonsterAndHeroGame.Models.Response;
using System.Collections.Generic;

namespace EasyTestAnyThing.MSClass.New.MonsterAndHeroGame
{
    /*
     * 2022/03/19
     * 在 C# 中使用 do-while 和 while 陳述式將迴圈邏輯新增至您的程式碼
     * 英雄和怪物會從 10 個體力點開始。
     * 所有攻擊都會是介於 1 和 10 之間的值。
     * 英雄會先進行攻擊。
     * 顯示怪物喪失的體力數，以及他們剩餘的體力。
     * 若怪物的體力大於 0，它便可以攻擊英雄。
     * 顯示英雄喪失的體力數，以及他們剩餘的體力。
     * 繼續這一系列的攻擊，直到怪物或英雄的體力為零或低於零。
     * 顯示獲勝者。
    */

    public class MonsterHeroGame
    {
        private Creature _first;
        private Creature _second;

        public FightingResponse Start(Creature attackBy, Creature target)
        {
            var fightingRecord = new List<FightingRecord>();
            _first = attackBy;
            _second = target;

            do
            {
                if (AttackerDieThenBreak())
                {
                    break;
                }

                var doDamage = attackBy.Attack();

                fightingRecord.Add(new FightingRecord()
                {
                    AttackBy = attackBy.Name,
                    DoDamage = doDamage,
                    Target = target.Name,
                    AffterTargetHp = target.LoseHp(doDamage)
                });

                SwichAttack(ref attackBy,ref target);

                
            } while (_first.Hp >= 0 && _second.Hp >= 0);

            return new FightingResponse()
            {
                FightingRecord = fightingRecord,
                Winner = _first.Hp > 0 ? _first.Name : _second.Name
            };
        }

        public void SwichAttack(ref Creature attackBy, ref Creature target) 
        {
            if (attackBy == _first)
            {
                attackBy = _second;
                target = _first;
            }
            else
            {
                attackBy = _first;
                target = _second;
            }
        }

        public bool AttackerDieThenBreak() 
        {
            if (_first.Hp <= 0 || _second.Hp <= 0)
            {
                return true;
            }
            return false;
        }
    }
}