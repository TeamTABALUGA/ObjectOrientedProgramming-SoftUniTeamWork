using RPGGame.Weapons;

namespace RPGGame
{
    using System;

    public abstract class Weapon
    {
        private WeaponType name;
        private float damage;
        private float range;

        public Weapon(WeaponType name, float damage, float range) 
        {
            this.Name = name;
            this.Damage = damage;
            this.Range = range;
        }

        public WeaponType Name { get; private set; }

        public float Damage
        {
            get { return this.damage; }
            set { this.damage = value; }
        }
        public float Range // TODO: do we need x, y props for weapon?
        {
            get { return this.range; }
            private set { this.range = value; }
        }
    }
}
