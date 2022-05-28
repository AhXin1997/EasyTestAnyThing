using System;

namespace EasyTestAnyThing.Training.MSClass.MonsterAndHeroGame.Models
{
    public class Creature
    {
        public Creature(string name, int hp, int minAttack, int maxAttack)
        {
            _name = name;
            _hp = hp;
            _minAttack = minAttack;
            _maxAttack = maxAttack;
            _rand = new Random(Guid.NewGuid().GetHashCode());
        }

        public int Hp => _hp;
        public string Name => _name;

        private int _hp;

        private readonly string _name;

        private readonly Random _rand;

        private readonly int _minAttack;

        private readonly int _maxAttack;

        public int Attack()
        {
            return _rand.Next(_minAttack, _maxAttack + 1);
        }

        public int LoseHp(int loseHp)
        {
            return _hp -= loseHp;
        }
    }
}