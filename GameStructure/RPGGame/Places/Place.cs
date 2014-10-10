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
            this.X = positionX;
            this.Y = positionY;
            this.Z = positionZ;
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

        public double X
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public double Y
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public double Z
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
