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

        public Throw GetPlayerTurnThrow(string playerName)
        {
            Console.WriteLine(playerName);

            var throws = new Throw();
            Console.Write("Enter first throw: ");
            throws.FirstThrow = int.Parse(Console.ReadLine());
            Console.Write("Enter second throw: ");
            throws.SecondThrow = int.Parse(Console.ReadLine());

            return throws;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*** Welcome to the Bowling Counter ***");
            Console.WriteLine("**************************************");
            Console.WriteLine("\r\n");

            Console.WriteLine("MENU : ");
            Console.WriteLine("1- Start a new game");
            Console.WriteLine("3- Exit");
        }

        public string GetPlayerResponse()
        {
            var response = Console.ReadLine();
            return string.IsNullOrEmpty(response) ? "" : response;
        }
    }
}
