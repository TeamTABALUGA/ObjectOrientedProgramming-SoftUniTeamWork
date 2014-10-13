namespace RPGGame
{
    using System;
    using RPGGame.Interfaces;

    public abstract class Place : IPosition
    {
        private string name;

        public Place(string name, float positionX, float positionY, float positionZ)
        {
            this.Name = name;
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.PositionZ = positionZ;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                bool isNullOrEmpty = string.IsNullOrEmpty(value);
                if(isNullOrEmpty)
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        public double PositionZ { get; set; }
    }
}
