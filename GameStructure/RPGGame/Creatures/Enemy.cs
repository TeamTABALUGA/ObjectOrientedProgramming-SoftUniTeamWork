using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RPGGame.Weapons;

namespace RPGGame
{
    public class Enemy : Creature
    {
        private EnemyWeapon enemyWeapon;

        public Enemy(float resistanse, EnemyWeapon enemyWeapon)
            : base(resistanse)
        {
            this.EnemyWeapon = enemyWeapon;
        }

        public EnemyWeapon EnemyWeapon { get; private set; }

        public override void MakeDamage(Creature creature)
        {
            creature.Health -= this.EnemyWeapon.Damage;
        }
    }
}
