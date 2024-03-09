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

            for (int i = 1; i < NumberOfTurns+1; i++)
            {
                foreach (var player in _players)
                {
                    RunATurn(player, i);
                }
            }

            _playersRecord.AddRange(_players);
            _players.Clear();
        }

        public void DisplayHighScores()
        {
            _interfaceManager.DisplayHighScores(_playersRecord
                .OrderBy(x => x.Score.GetScore())
                .Take(5)
            );
        }

        private void RunATurn(Player player, int turnNumber)
        {
            var turnThrow = _interfaceManager.GetPlayerTurnThrow(player.PlayerName, turnNumber);

            player.PlayATurn(turnThrow.FirstThrow, turnThrow.SecondThrow);

            _interfaceManager.EndTurn(player);
        }

        private void CreatePlayers()
        {
            var numberOfPlayers = _interfaceManager.GetPlayerNumber();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                var playerName = _interfaceManager.GetPlayerName();
                _players.Add(new Player(playerName));
            }
        }
    }
}
