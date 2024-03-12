namespace BowlingCounter;

public class GameManager
{
    private readonly MenuManager _menuManager;
    private readonly BowlingCounter _game;

    public GameManager(MenuManager menuManager, BowlingCounter game)
    {
        ArgumentNullException.ThrowIfNull(menuManager);
        ArgumentNullException.ThrowIfNull(game);
        _menuManager = menuManager;
        _game = game;
    }

    public void Launch()
    {
        _menuManager.DisplayTitle("Welcome to Bowling Counter");
        _menuManager.DisplayMenu();
        var userChoice = _menuManager.GetUserSelection();
        if (string.IsNullOrWhiteSpace(userChoice.Error))
        {
            Console.WriteLine(userChoice.Error);
            return;
        }
        
        switch (userChoice.UserChoice)
        {
            case 1:
                _game.Start();
                break; 
            case 2:
                _menuManager.End();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}