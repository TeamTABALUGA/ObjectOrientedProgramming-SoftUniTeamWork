namespace RPGGame.Characteristics
{
    using System;
    using RPGGame.Interfaces;
    public abstract class HealthSystem : IHealth
    {
        public const float START_HEALTH = 100;
        public const float DEAD = 0;
        public const float START_RESISTANCE = 1;
        private float currentHealth;
        private float resistance;

        public HealthSystem(float resistance)
        {
            this.Resistance = resistance;
            this.CurrentHealth = START_HEALTH * this.Resistance;
        }

        public float CurrentHealth { get; set; }

        public float Resistance
        {
            get
            {
                return this.resistance;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Resistance cannot be zero or negative");
                }

                this.resistance = value;
            }
        }

        public bool IsAlive(IHealth creature)
        {
            bool isAlive = creature.CurrentHealth > 0;
            if (isAlive)
            {
                return true;
            }
            else
            {
                FaithOfCreature();
                return false;
            }
        }

        public void DecreaseHealth(IHealth creature, Weapon weapon)
        {
            float decreasedHealth = creature.CurrentHealth - weapon.Damage;
            creature.CurrentHealth = decreasedHealth;
        }

        public abstract void FaithOfCreature();
    }
}
