using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyTestAnyThing.MSClass
{
    public class MosterAndHeroGame
    {
        /*
            2022/0105
            在 C# 中使用 do-while 和 while 陳述式將迴圈邏輯新增至您的程式碼

            MosterAndHeroGame()
            英雄和怪物會從 10 個體力點開始。
            所有攻擊都會是介於 1 和 10 之間的值。
            英雄會先進行攻擊。
            顯示怪物喪失的體力數，以及他們剩餘的體力。
            若怪物的體力大於 0，它便可以攻擊英雄。
            顯示英雄喪失的體力數，以及他們剩餘的體力。
            繼續這一系列的攻擊，直到怪物或英雄的體力為零或低於零。
            顯示獲勝者。
       */
        private Carture _hero;
        private Carture _monster;

        public MosterAndHeroGame(Carture hero, Carture monster)
        {
            _hero = hero;
            _monster = monster;
        }

        public MonsterAndHeroGameRespond Run()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var attacker = _hero;
            var beAttack = _monster;

            var log = new List<MonsterAndHeroGameFightLog>();

            do
            {
                var attack = random.Next(attacker.MinAttack, attacker.MaxAttack + 1);

                log.Add(new MonsterAndHeroGameFightLog
                {
                    Attacker = attacker.Name,
                    Target = beAttack.Name,
                    LostHp = attack,
                    TargetHp = beAttack.HP -= attack
                });

                //如果攻擊者為hero 則更換為 monster
                if (attacker == _hero)
                {
                    attacker = _monster;
                    beAttack = _hero;
                }
                //如果攻擊者為monster 則更換為 hero
                else
                {
                    attacker = _hero;
                    beAttack = _monster;
                }
            } while (_hero.HP > 0 && _monster.HP > 0);

            return new MonsterAndHeroGameRespond() { Log = log };
        }
    }

    public class MonsterAndHeroGameRespond
    {
        public MonsterAndHeroGameRespond()
        {
            //Log = new List<MonsterAndHeroGameFightLog>();
        }

        public List<MonsterAndHeroGameFightLog> Log { get; set; }

        public string Winner
        {
            get
            {
                return Log.ToList().First(w => w.TargetHp <= 0).Attacker + " is Winner!";
            }
        }

        // => Log.ToList().First(w => w.TargetHp <= 0).Attacker + " is Winner!";
    }

    public class MonsterAndHeroGameFightLog
    {
        public string Attacker { get; set; }
        public string Target { get; set; }
        public int LostHp { get; set; }
        public int TargetHp { get; set; }
    }

    public class Carture
    {
        public Carture(string name, int hp, int minAttack, int maxAttack)
        {
            Name = name;
            HP = hp;
            MinAttack = minAttack;
            MaxAttack = maxAttack;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }
    }

    public class Hero : Carture
    {
        public Hero(string name, int hp, int minAttack, int maxAttack) : base(name, hp, minAttack, maxAttack)
        {
        }
    }

    public class Monster : Carture
    {
        public Monster(string name, int hp, int minAttack, int maxAttack) : base(name, hp, minAttack, maxAttack)
        {
        }
    }
}