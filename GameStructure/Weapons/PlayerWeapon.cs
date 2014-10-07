namespace RPGGame.Weapons
{
    using System;

    public class PlayerWeapon : Weapon, IFightable
    {
        public PlayerWeapon(WeaponType name, float damage, float range)
            : base(name, damage, range)
        {
        }

        public void UseWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
