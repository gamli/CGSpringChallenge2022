using System.Collections.Generic;
using System.Numerics;

namespace CGSpringChallenge2022
{
    public class GameState
    {
        private readonly int _lives1;
        private readonly int _lives2;
        private readonly int _mana1;
        private readonly int _mana2;
        private readonly Vector2 _base1;
        private readonly Vector2 _base2;
        private readonly List<Hero> _heroes1;
        private readonly List<Hero> _heroes2;
        private readonly List<Monster> _monsters;

        public GameState(
            int lives1,
            int lives2,
            int mana1,
            int mana2,
            Vector2 base1,
            Vector2 base2,
            List<Monster> monsters,
            List<Hero> heroes1,
            List<Hero> heroes2)
        {
            _lives1 = lives1;
            _lives2 = lives2;
            _base1 = base1;
            _base2 = base2;
            _monsters = monsters;
            _heroes1 = heroes1;
            _heroes2 = heroes2;
            _mana1 = mana1;
            _mana2 = mana2;
        }

        public int Lives(int player) => player == 1 ? _lives1 : _lives2;
        public int Mana(int player) => player == 1 ? _mana1 : _mana2;
        public Vector2 Base(int player) => player == 1 ? _base1 : _base2;
        public List<Hero> Heroes(int player) => player == 1 ? _heroes1 : _heroes2;
        public List<Monster> Monsters() => _monsters;
    }
}