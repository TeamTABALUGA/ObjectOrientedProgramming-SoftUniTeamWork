namespace RPGGame
{
    using RPGGame.Interfaces;

    public class Portal : Place, IPosition, IRateable
    {
        private float rate;

        public Portal(string name, float positionX, float positionY, float positionZ, float rate)
            : base(name, positionX, positionY, positionZ)
        {
            this.Rate = rate;
        }

        public float Rate
        {
            get { return this.rate; }
            set { this.rate = value; }
        }
    }
}
