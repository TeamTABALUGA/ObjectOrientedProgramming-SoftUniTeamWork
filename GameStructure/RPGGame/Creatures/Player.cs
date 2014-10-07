using System.Collections.Generic;
using RPGGame.Weapons;

namespace RPGGame
{
    public class Player : Creature
    {
        private int currentWeaponIndex;
        private List<PlayerWeapon> playerWeapons;

        //public int DamageResistance;
        public Player(float resistance, List<Weapon> playerWeapons)
            : base(resistance)
        {
            //this.DamageResistance = damageResistance;
            this.PlayerWeapons = playerWeapons;
        }


        public IList<Weapon> PlayerWeapons { get; set; }

        public int CurrentWeaponIndex
        {
            get { return this.currentWeaponIndex; }
            set { this.currentWeaponIndex = value; }
        }

        public override void MakeDamage(Creature creature)
        {
            creature.Health -= this.PlayerWeapons[this.CurrentWeaponIndex].Damage;
        }

    }
}
