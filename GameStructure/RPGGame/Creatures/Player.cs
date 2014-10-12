using RPGGame.Characteristics;
using RPGGame.Interfaces;

namespace RPGGame
{
    using System;
    using System.Collections.Generic;
    using RPGGame.Weapons;

    public class Player : Experience
    {
        private int currentWeaponIndex;
        private List<PlayerWeapon> playerWeapons;
        private float resistance;

        //public int DamageResistance;
        public Player(float resistance, List<Weapon> playerWeapons, float level)
            : base()
        {
            //this.DamageResistance = damageResistance;
            this.PlayerWeapons = playerWeapons;
            this.Level = level;
            this.CurrentExperience = 0;
            this.ExperienceWhoUpLevels = 3000;
            this.Level = 0;
        }

        public IList<Weapon> PlayerWeapons { get; set; }

        public int CurrentWeaponIndex
        {
            get { return this.currentWeaponIndex; }
            set { this.currentWeaponIndex = value; }
        }

        public float Resistance
        {
            get { return this.resistance; }
            set { this.resistance = value; }
        }

        public override void IncreaseExperience(IHealth creature, Creatures.EnemyDifficulty enemyDifficulty)
        {
            bool creatureIsDead = !creature.IsAlive(creature);
            if (creatureIsDead)
            {
                this.CurrentExperience += (float)enemyDifficulty;
                UpdateLevel();
            }
        }

        public override void UpdateLevel()
        {
            if (this.CurrentExperience >= this.ExperienceWhoUpLevels)
            {
                this.Level++;
                this.ExperienceWhoUpLevels = this.CurrentExperience * MULTIPLICATION_INDEX;
            }
        }
    }
}
