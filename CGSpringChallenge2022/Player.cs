using System;
using System.Linq;
using CGSpringChallenge2022;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
public class Player
{
    public const int PLAYER_ME = 1;
    public const int PLAYER_OPPONENT = 2;

    static void Main(string[] args)
    {
        var inputParser = new InputParser();

        // game loop
        while (true)
        {
            var gameState = inputParser.Parse();

            var myHeroes = gameState.Heroes(PLAYER_ME);

            var threats =
                gameState.Monsters()
                         .Where(monster => monster.IsThreatForPlayer == PLAYER_ME)
                         .OrderBy(monster => Geometry.DistanceSqr(monster.Position, gameState.Base(PLAYER_ME)))
                         .Take(3)
                         .ToList();

            var orders =
                myHeroes.Select(hero => threats.OrderBy(monster => Geometry.DistanceSqr(monster.Position, hero)).FirstOrDefault())
                        .Select(
                            nearestThreat =>
                            {
                                if (nearestThreat == null)
                                {
                                    return "WAIT";
                                }

                                return "MOVE " + (int)nearestThreat.Position.X + " " + +(int)nearestThreat.Position.Y;
                            })
                        .ToList();

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }

            // for (var i = 0; i < myHeroes.Count; i++)
            // {
            //     
            //     
            //     // In the first league: MOVE <x> <y> | WAIT; In later leagues: | SPELL <spellParams>;
            //     // Console.WriteLine("WAIT");
            // }
        }
    }
}