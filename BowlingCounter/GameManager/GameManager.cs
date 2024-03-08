using BowlingCounter.Interface;

namespace BowlingCounter.GameManager
{
    public class GameManager : IGameManager
    {
        private readonly IInterfaceManager _interfaceManager;

        private List<Player> _players = new();
        private List<Player> _playersRecord = new();

        private const int NumberOfTurns = 10;

        public GameManager(IInterfaceManager interfaceManager)
        {
            _interfaceManager = interfaceManager;
        }

        public void PlayAGame()
        {
            CreatePlayers();

            for (int i = 0; i < NumberOfTurns; i++)
            {
                foreach (var player in _players)
                {
                    RunATurn(player);
                }
            }
        }

        private void RunATurn(Player player)
        {
            var turnThrow = _interfaceManager.GetPlayerTurnThrow(player.PlayerName);

            player.PlayATurn(turnThrow.FirstThrow, turnThrow.SecondThrow);

            Console.WriteLine("Total Score: " + totalScore);

            // Print the throws in a table
            Console.WriteLine("Throws:");
            for (int j = 0; j <= i; j++)
            {
                Console.Write("| " + firstThrows[playerNumber][j] + " " + secondThrows[playerNumber][j] + " ");
            }

            Console.WriteLine("|");

        }

        private void CreatePlayers()
        {
            var numberOfPlayers = _interfaceManager.GetPlayerNumber();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                _players.Add(new Player("Player" + " " + i));
            }


        }
    }
}
