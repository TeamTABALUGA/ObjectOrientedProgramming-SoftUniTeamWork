namespace RPGGame.Characteristics
{
    using RPGGame.Interfaces;
    public abstract class HealthSystem : Experience, IHealth
    {
        public const float START_HEALTH = 100;
        public const float DEAD = 0;
        private float currentHealth;

        public float CurrentHealth { get; set; }

        public bool IsAlive(IHealth creature)
        {
            bool isAlive = creature.CurrentHealth > 0;
            if(isAlive)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void DecreaseHealth(IHealth creature, Weapon weapon)
        {
            float decreasedHealth = creature.CurrentHealth - weapon.Damage;
            creature.CurrentHealth = decreasedHealth;
        }

    }
}
