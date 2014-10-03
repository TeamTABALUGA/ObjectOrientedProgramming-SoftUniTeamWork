using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGGame
{
    public class Player : Creature, ILive
    {
        public int DamageResistance;
        public Player(string name, int health, int damageResistance)
            : base(name, health)
        {
            this.DamageResistance = damageResistance;
        }

        public void CurrentDamageResistance()
        {
            
        }
    }
}
