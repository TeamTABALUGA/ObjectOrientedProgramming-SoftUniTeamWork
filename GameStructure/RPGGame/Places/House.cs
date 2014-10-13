namespace RPGGame.Places
{
    using RPGGame.Interfaces;

    public class House : Place, IPosition
    {
        public House(string name, float positionX, float positionY, float positionZ)
            : base(name, positionX, positionY, positionZ)
        {
        }
    }
}
