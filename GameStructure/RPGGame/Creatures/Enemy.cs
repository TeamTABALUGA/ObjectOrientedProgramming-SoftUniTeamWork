namespace RPGGame
{
    using RPGGame.Weapons;
    using RPGGame.Creatures;
    using Characteristics;
    using RPGGame.Interfaces;

    public class Enemy : HealthSystem, IPosition
    {
        private EnemyWeapon enemyWeapon;
        private EnemyDifficulty difficult;
        private float rangeEnemy;

        public Enemy(float range, EnemyWeapon enemyWeapon,
            EnemyDifficulty difficulty, float positionX,
            float positionY, float positionZ, float resistance = START_RESISTANCE)
            : base(resistance)
        {
            this.EnemyWeapon = enemyWeapon;
            this.Difficult = difficulty;
            this.RangeEnemy = range;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.PositionZ = positionZ;
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

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        public double PositionZ { get; set; }

        public override void FaithOfCreature()
        {
           // Destroy(); 
           // TODO: Unity
        }
    }
}
