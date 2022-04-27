using System.Numerics;

namespace CGSpringChallenge2022
{
    public class Monster
    {
        public Monster(
            int id,
            Vector2 position,
            int shieldLife,
            bool isControlled,
            int health,
            Vector2 trajectory,
            bool isTargetingBase,
            int isThreatForPlayer)
        {
            Id = id;
            Position = position;
            ShieldLife = shieldLife;
            IsControlled = isControlled;
            Health = health;
            Trajectory = trajectory;
            IsTargetingBase = isTargetingBase;
            IsThreatForPlayer = isThreatForPlayer;
        }

        public int Id { get; }
        public Vector2 Position { get; }
        public int ShieldLife { get; }
        public bool IsControlled { get; }
        public int Health { get; }
        public Vector2 Trajectory { get; }
        public bool IsTargetingBase { get; }
        public int IsThreatForPlayer { get; }
    }
}