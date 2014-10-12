using System;
using RPGGame.Creatures;
using RPGGame.Interfaces;

namespace RPGGame.Characteristics
{
    public abstract class Experience : IExperience
    {
        public const float MULTIPLICATION_INDEX = 1.6f;
        private float currentExperience;
        private float experienceWhoUpLevels;
        private float level;

        public float CurrentExperience
        {
            get { return this.currentExperience; }
            set { this.currentExperience = value; }
        }

        public float ExperienceWhoUpLevels
        {
            get { return this.experienceWhoUpLevels; }
            set {this. experienceWhoUpLevels = value; }
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
                if (isNegative)
                {
                    throw new IndexOutOfRangeException("Level cannot be negative");
                }

                this.level = value;
            }
        }

        public abstract void IncreaseExperience(IHealth creature, EnemyDifficulty enemyDifficulty);

        public abstract void UpdateLevel();

    }
}
