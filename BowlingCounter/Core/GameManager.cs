namespace BowlingCounter;

public class GameManager
{
    private readonly MenuManager _menuManager;

    public GameManager(MenuManager menuManager)
    {
        ArgumentNullException.ThrowIfNull(menuManager);
        _menuManager = menuManager;
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
                _game.DisplayScore();
                break;
            case 3:
                _game.End();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}