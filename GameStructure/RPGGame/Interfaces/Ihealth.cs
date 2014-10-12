namespace RPGGame.Interfaces
{
    public interface IHealth
    {
        float CurrentHealth { get; set; }
        bool IsAlive(IHealth creature);
        void DecreaseHealth(IHealth creature, Weapon weapon);
    }
}
