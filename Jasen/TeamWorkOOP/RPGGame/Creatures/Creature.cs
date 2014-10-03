using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{
    public abstract class Creature : IWalk, ILive
    {
        public const int MaxHealth = 100;
        public const int MinHeath = 0;
        private int health = MaxHealth;
        public string Name { get; private set; }
        public bool IsAlive { get; set; }
        public int AttackResistance { get; private set; }
        public int AttackStrength { get; private set; }

        // Health points :  max - 100, min -1, 0 = death
        public int Health
        {
            get { return this.health; }
            set
            {
                if ((value < 0) || (value > 100))
                {
                    throw new ArgumentOutOfRangeException(String.Format("Health propertu out of range asigned value : {0}", value));
                }
                this.health = value;
            }
        }

        public Creature(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }

        public Creature()
        {
            
        }
        public void CreatureLiveStatus(int health)
        {
            if (health < MinHeath)
            {
                IsAlive = false;
            }
        }
    }
}
