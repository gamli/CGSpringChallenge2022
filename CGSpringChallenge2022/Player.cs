using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

            var heroes = gameState.Heroes(PLAYER_ME);

            var threats =
                gameState.Monsters()
                         .Where(monster => monster.IsThreatForPlayer == PLAYER_ME)
                         .OrderBy(monster => Geometry.DistanceSqr(monster.Position, gameState.Base(PLAYER_ME)))
                         .Take(heroes.Count)
                         .ToList();
            
            var availableHeroes = new HashSet<Hero>(heroes);
            
            var orders = new List<(int, string)>();

            while (threats.Any() && availableHeroes.Any())
            {
                foreach (var monster in threats)
                {
                    if (!availableHeroes.Any())
                    {
                        break;
                    }
                    
                    var nearestHero = availableHeroes.OrderBy(hero => Geometry.DistanceSqr(hero.Position, monster.Position)).First();
                    var heroIdx = heroes.IndexOf(nearestHero);
                    var order = "MOVE " + (int)monster.Position.X + " " + +(int)monster.Position.Y;
                    orders.Add((heroIdx, order));
                    availableHeroes.Remove(nearestHero);
                    
                    Console.Error.WriteLine("Hero " + nearestHero.Id + " moving towards monster " + monster.Id);
                }
            }
            
            orders.AddRange(availableHeroes.Select(hero => (heroes.IndexOf(hero), "WAIT")));

            foreach (var order in orders.OrderBy(idxCommand => idxCommand.Item1).Select(idxCommand => idxCommand.Item2))
            {
                Console.WriteLine(order);
            }
        }
    }
}