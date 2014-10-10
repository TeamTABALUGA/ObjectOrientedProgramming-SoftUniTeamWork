namespace RPGGame
{
    using System;

    public abstract class Creature :IMovable, ILivable
    {
        private const int StartHealth = 100;
        private const int Dead = 0;
        private float health;
        // resistance increases with the experiece of the player
        private float resistance;

        public Creature(float resistance)
        {
            this.Resistance = resistance;
            this.Health = Creature.StartHealth * resistance;
        }

        // Health points :  max - 100, min -1, 0 = death
        public float Health
        {
            get { return this.health; }
            set
            {
                if ((value < 0) || (value > 100))
                {
                    throw new ArgumentOutOfRangeException(String.Format("Health property is out of range asigned value : {0}", value));
                }
                this.health = value;
            }
        }

        public float Resistance
        {
            get { return this.resistance; }
            set { this.resistance = value; }
        }

        public bool IsAlive()
        {
            if (this.Health <= Creature.Dead)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public abstract void MakeDamage(Creature creature);
    }
}
