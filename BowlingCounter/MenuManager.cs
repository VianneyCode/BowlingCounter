using System.Net.Mime;
using BowlingCounter.GameManager;
using BowlingCounter.Interface;

namespace BowlingCounter
{
    public class MenuManager
    {
        private readonly IInterfaceManager _interfaceManager;
        private readonly IGameManager _gameManager;

        public MenuManager(IInterfaceManager interfaceManager, IGameManager gameManager)
        {
            _interfaceManager = interfaceManager;
            _gameManager = gameManager;
        }

        public void RunGame()
        {
            while (true)
            {
                _interfaceManager.DisplayMenu();
                var choice = _interfaceManager.GetPlayerResponse();

                if (choice == "1")
                {
                    _gameManager.PlayAGame();
                }

                if (choice == "2")
                {
                    _gameManager.DisplayHighScores();
                }

                if (choice == "3")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
