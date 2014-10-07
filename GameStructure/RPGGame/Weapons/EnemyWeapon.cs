namespace RPGGame.Weapons
{
    using System;

    public class EnemyWeapon : Weapon, IFightable
    {
        public EnemyWeapon(WeaponType name, float damage, float range)
            : base(name, damage, range)
        {
        }

        public void UseWeapon()
        {
            Console.WriteLine("I am enemy. I use my body for weapon.");
        }
    }
}
