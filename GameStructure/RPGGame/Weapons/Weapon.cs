using RPGGame.Weapons;

namespace RPGGame
{
    using System;

    public abstract class Weapon
    {
        // 
        private float weaponId;
        
        private WeaponType name;
        private float damage;
        
        // Will be range - force
        private float range;

        // time to wait before next shooting
        private float delay;
        

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
