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
            _interfaceManager.DisplayMenu();
            var choice = _interfaceManager.GetPlayerResponse();

            if (choice == "1")
            {
                _gameManager.PlayAGame();
            }
            if (choice == "2")
            {

            }
        }
    }
}
