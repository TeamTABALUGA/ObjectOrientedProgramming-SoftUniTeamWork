using RPGGame.Characteristics;
using RPGGame.Interfaces;

namespace RPGGame
{
    using System.Collections.Generic;
    using RPGGame.Weapons;

    public class Player : Experience, IPosition
    {
        private int currentWeaponIndex;
        private List<PlayerWeapon> playerWeapons;

        //public int DamageResistance;
        public Player(List<Weapon> playerWeapons,
            float positionX, float positionY, float positionZ,
            float level = 0, float resistance = START_RESISTANCE)
            : base(level, resistance)
        {
            // this.DamageResistance = damageResistance;
            this.PlayerWeapons = playerWeapons;
            this.CurrentWeaponIndex = 0;
            this.CurrentExperience = 0;
            this.ExperienceWhoUpLevels = 3000;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.PositionZ = positionZ;
        }

        public IList<Weapon> PlayerWeapons { get; set; }

        public int CurrentWeaponIndex
        {
            get { return this.currentWeaponIndex; }
            set { this.currentWeaponIndex = value; }
        }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        public double PositionZ { get; set; }

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
                IncreaseHealthByLevel();
                UnlockWeaponIndex();
            }
        }

        public override void IncreaseHealthByLevel()
        {
            this.Resistance++; // TODO: Think of amount by which resistance will be increased 
            this.CurrentHealth *= this.Resistance;
        }

        public override void FaithOfCreature()
        {
            if (this.Level > 0)
            {
                this.Level--;// TODO: Think of amount by which resistance will be decreased 
            }
            if (this.Resistance > START_RESISTANCE)
            {
                this.Resistance--; // TODO: Think of amount by which resistance will be decreased 
            }

            this.CurrentHealth = START_HEALTH * this.Resistance;
            this.PositionX = 0; // TODO: Adjust player's coordinates
            this.PositionY = 0;
            this.PositionZ = 0;
        }

        public override void UnlockWeaponIndex()
        {
            int biggestIndexOfWeapon = this.PlayerWeapons.Count;
            int unlockStepLevel = 2;

            if (this.Level % unlockStepLevel == 0)
            {
                if (this.currentWeaponIndex - 1 < biggestIndexOfWeapon)
                {
                    this.currentWeaponIndex++;
                }
            }
        }
    }
}
