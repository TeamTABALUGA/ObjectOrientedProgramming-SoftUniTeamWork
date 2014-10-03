using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGGame
{
    public abstract class Weapon
    {
        public string Name { get; set; }
        public string DamageType { get; set; }
        public int DamageStrength { get; set; }
        public double ShootRange { get; set; }

        public Weapon(string name, string damageType, int damageStrength, double shootRange)
        {
            this.Name = name;
            this.DamageType = damageType;
            this.DamageStrength = damageStrength;
            this.ShootRange = shootRange;
        }
    }
}
