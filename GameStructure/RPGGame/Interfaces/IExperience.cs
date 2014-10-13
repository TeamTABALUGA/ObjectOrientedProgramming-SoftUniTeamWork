namespace RPGGame.Interfaces
{
    using RPGGame.Creatures;
    public interface IExperience
    {
        float CurrentExperience { get; set; }
        void IncreaseExperience(IHealth creature, EnemyDifficulty enemyDifficulty);
        void IncreaseHealthByLevel();
        void UnlockWeaponIndex();

    }
}
