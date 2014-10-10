namespace RPGGame
{
    using System;
    using System.Collections.Generic;
    using RPGGame.Weapons;

    public class Player : Creature
    {
        private int currentWeaponIndex;
        private List<PlayerWeapon> playerWeapons;
        private float experience;
        private float level;

        //public int DamageResistance;
        public Player(float resistance, List<Weapon> playerWeapons,float level, float experience = 0)
            : base(resistance)
        {
            //this.DamageResistance = damageResistance;
            this.PlayerWeapons = playerWeapons;
            this.Experience = experience;
            this.Level = level;
        }


        public IList<Weapon> PlayerWeapons { get; set; }

        public int CurrentWeaponIndex
        {
            get { return this.currentWeaponIndex; }
            set { this.currentWeaponIndex = value; }
        }

        public float Experience
        {
            get
            {
                return experience;
            }

            set
            {
                experience = value;
            }
        }

        public float Level
        {
            get
            {
                return this.level;
            }

            set
            {
                bool isNegative = value < 0;
                if(isNegative)
                {
                    throw new IndexOutOfRangeException("Level cannot be negative");
                }

                this.level = value;
            }
        }

        public override void MakeDamage(Creature creature)
        {
            creature.Health -= this.PlayerWeapons[this.CurrentWeaponIndex].Damage;
        }

    }
}
