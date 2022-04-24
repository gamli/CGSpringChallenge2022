using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CGSpringChallenge2022
{
    public class InputParser
    {
        private readonly Vector2 _base1;
        private readonly Vector2 _base2;

        public InputParser()
        {
            var xy = ReadInts();
            _base1 = new Vector2(xy[0], xy[1]);
            _base2 = xy[0] == 0 ? new Vector2(17630, 9000) : new Vector2(0, 0);
            Console.ReadLine(); // read number of heroes always 3... discard
        }

        public GameState Parse()
        {
            var healthMana1 = ReadInts();
            var healthMana2 = ReadInts();

            var monsters = new List<Monster>();
            var heroes1 = new List<Vector2>();
            var heroes2 = new List<Vector2>();

            var entityCount = int.Parse(Console.ReadLine()!);

            for (var i = 0; i < entityCount; i++)
            {
                var entityData = ReadInts();
                var id = entityData[0]; // Unique identifier
                var type = entityData[1]; // 0=monster, 1=your hero, 2=opponent hero
                var x = entityData[2]; // Position of this entity
                var y = entityData[3];
                var shieldLife = entityData[4]; // Ignore for this league; Count down until shield spell fades
                var isControlled = entityData[5]; // Ignore for this league; Equals 1 when this entity is under a control spell
                var health = entityData[6]; // Remaining health of this monster
                var vx = entityData[7]; // Trajectory of this monster
                var vy = entityData[8];
                var nearBase = entityData[9]; // 0=monster with no target yet, 1=monster targeting a base
                var threatFor = entityData[10]; // Given this monster's trajectory, is it a threat to 1=your base, 2=your opponent's base, 0=neither

                if (type == 0)
                {
                    monsters.Add(
                        new Monster(
                            id,
                            new Vector2(x, y),
                            shieldLife,
                            isControlled == 1,
                            health,
                            new Vector2(vx, vy),
                            nearBase == 1,
                            threatFor));
                }
                else
                {
                    var heroes = type == 1 ? heroes1 : heroes2;
                    heroes.Add(new Vector2(x, y));
                }
            }

            return new GameState(
                healthMana1[0],
                healthMana2[0],
                healthMana1[1],
                healthMana2[1],
                _base1,
                _base2,
                monsters,
                heroes1,
                heroes2);
        }

        private int[] ReadInts() => Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
    }
}