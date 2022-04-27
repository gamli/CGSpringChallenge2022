using System.Numerics;

namespace CGSpringChallenge2022
{
    public class Hero
    {
        public Hero(int id, Vector2 position)
        {
            Id = id;
            Position = position;
        }

        public int Id { get; }
        public Vector2 Position { get; }
    }
}