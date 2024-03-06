namespace BowlingCounter.Models;

public class BowlingGame
{
    private List<PlayerGame> _players = new();
    private Menu _gameMenu = new Menu(new List<string>
    {
        "Add a player",
        "List current players",
        "Start the game",
        "Back"
    });
    
    public void LaunchMenu()
    {
        Console.Clear();
        _gameMenu.DisplayMenu();
        var useChoice = _gameMenu.UserSelectOption();

        switch (useChoice)
        {
            case 1:
                AddPlayer();
                break;
            case 2:
                ListCurrentPlayers();
                break;
            case 3:
                foreach (var player in _players)
                {
                    Console.WriteLine();
                }
                break;
            case 4:
                break;
        }
    }
    
    private void AddPlayer()
    {
        Console.WriteLine("Enter the name of the player you want to add: ");
        var playerName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(playerName))
        {
            Console.WriteLine("The name of the player cannot be empty");
            Thread.Sleep(2000);
            DisplayerManager.ClearLines(numberOfLine: 3);
            Console.WriteLine("Enter the name of the player you want to add: ");
            playerName = Console.ReadLine();
        }
        _players.Add(new PlayerGame(playerName));
        LaunchMenu();
    }

    private void ListCurrentPlayers()
    {
        Console.Clear();
        if(_players.Count == 0)
        {
            Console.WriteLine("No player added yet");
            return;
        }
        Console.WriteLine("Current players: ");
        foreach (var player in _players)
        {
            Console.WriteLine("- " + player.Name);
        }
        Console.WriteLine("Press any key to go back to the menu...");
        Console.ReadLine();
        LaunchMenu();
    }
    
    private void LaunchGame()
    {
        Console.Clear();
        Console.WriteLine("Let's play !");
        
        foreach (var player in _players)
        {
            Console.WriteLine("It's " + player.Name + "'s turn");
            Console.WriteLine("Enter the number of pins knocked down: ");
            Console.ReadLine();
            // while()
            // player.Roll();
            Console.WriteLine("Score: " + player.Score());
        }
        Console.WriteLine("Press any key to go back to the menu...");
        Console.ReadLine();
        LaunchMenu();
    }
}