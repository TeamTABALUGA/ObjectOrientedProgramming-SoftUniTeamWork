namespace RPGGame
{
    using RPGGame.Weapons;
    using RPGGame.Creatures;
    using Characteristics;
    using RPGGame.Interfaces;

    public class Enemy : HealthSystem
    {
        private EnemyWeapon enemyWeapon;
        private EnemyDifficulty difficult;
        private float rangeEnemy;

        public Enemy(float range, EnemyWeapon enemyWeapon, EnemyDifficulty difficulty)
        {
            this.EnemyWeapon = enemyWeapon;
            this.Difficult = difficulty;
            this.RangeEnemy = range;
        }

        public EnemyWeapon EnemyWeapon { get; private set; }

        public EnemyDifficulty Difficult
        {
            get { return this.difficult; }
            set { this.difficult = value; }
        }

        public float RangeEnemy
        {
            get { return this.rangeEnemy; }
            set { this.rangeEnemy = value; }
        }
    }
}
