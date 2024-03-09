using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingCounter.Interface
{
    public class InterfaceManager : IInterfaceManager
    {

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public int GetPlayerNumber()
        {
            Console.WriteLine("Enter number of players: ");
            return int.Parse(Console.ReadLine());
        }

        public Throw GetPlayerTurnThrow(string playerName, int turnNumber)
        {
            Console.WriteLine("Turn n°" + turnNumber);
            Console.WriteLine(playerName);

            Console.Write("Enter first throw: ");
            var firstThrow = int.Parse(Console.ReadLine());
            Console.Write("Enter second throw: ");
            var secondThrow = int.Parse(Console.ReadLine());

            return new Throw(firstThrow, secondThrow); ;
        }

        public void EndTurn(Player player)
        {
            Console.WriteLine("Total Score: " + player.Score.GetScore());

            // Print the throws in a table
            Console.WriteLine("Throws:");
            foreach(var currentThrow in player.GetAllThrows())
            {
                Console.Write("| " + currentThrow.FirstThrow + " " + currentThrow.SecondThrow + " ");
            }

            Console.WriteLine("|");
        }

        public void DisplayHighScores(IEnumerable<Player> highScorePlayers)
        {
            Console.WriteLine("High score :");
            Console.WriteLine("\r\n");

            foreach (var player in highScorePlayers.Select((value, i) => new {i, value}))
            {
                Console.WriteLine($"#{player.i+1} {player.value.Score.GetScore()} - {player.value.PlayerName}");
            }
        }

        public string GetPlayerName()
        {
            Console.Write("Type your player name : ");
            return Console.ReadLine() ?? "UnknownPlayer";
        }

        public void DisplayMenu()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*** Welcome to the Bowling Counter ***");
            Console.WriteLine("**************************************");
            Console.WriteLine("\r\n");

            Console.WriteLine("MENU : ");
            Console.WriteLine("1- Start a new game");
            Console.WriteLine("2- High Scores");
            Console.WriteLine("3- Exit");
        }

        public string GetPlayerResponse()
        {
            var response = Console.ReadLine();
            return string.IsNullOrEmpty(response) ? "" : response;
        }
    }
}
