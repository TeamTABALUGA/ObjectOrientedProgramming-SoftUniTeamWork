using RPGGame.Creatures;

namespace RPGGame
{
    using RPGGame.Weapons;

    public class Enemy : Creature
    {
        private EnemyWeapon enemyWeapon;
        private EnemyDifficult difficult;
        private float rangeEnemy;

        public Enemy(float resistanse, float range, EnemyWeapon enemyWeapon, EnemyDifficult difficulty)
            : base(resistanse)
        {
            this.EnemyWeapon = enemyWeapon;
            this.Difficult = difficulty;
            this.RangeEnemy = range;
        }

        public EnemyWeapon EnemyWeapon { get; private set; }

        public EnemyDifficult Difficult
        {
            get { return this.difficult; }
            set { this.difficult = value; }
        }

        public float RangeEnemy
        {
            get { return this.rangeEnemy; }
            set { this.rangeEnemy = value; }
        }

        public override void MakeDamage(Creature creature)
        {
            creature.Health -= this.EnemyWeapon.Damage;
        }
    }
}
