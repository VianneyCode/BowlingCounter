using BowlingCounter.Interfaces;

namespace BowlingCounter.Models;

public class Menu : IMenu
{
    private List<string> _options;
    private BowlingGame BowlingGame { get; set; }

    public Menu(List<string> options)
    {
        _options = options;
        BowlingGame = new BowlingGame();
    }

    public void DisplayTitle(string message)
    {
        Console.WriteLine(new string('*', message.Length + 8));
        Console.WriteLine("*** " + message + " ***");
        Console.WriteLine(new string('*', message.Length + 8));
        Console.WriteLine("\r\n");
    }
    
    public void DisplayMenu()
    {
        Console.WriteLine("*** MENU ***");
        for (var index = 0; index < _options.Count; index++)
        {
            var option = _options[index];
            Console.WriteLine((index+1) + " - " + option);            
        }

        Console.WriteLine("************");
    } 

    public int UserSelectOption()
    {
        Console.WriteLine("Enter your choice: ");
        var stringUserChoice = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(stringUserChoice) && !int.TryParse(stringUserChoice, out var choice) && (choice < 0 || choice > _options.Count))
        {
            Console.WriteLine("The selected option is invalid");
            Thread.Sleep(2000);
            DisplayerManager.ClearLines(numberOfLine: 3);
            Console.WriteLine("Enter your choice: ");
            stringUserChoice = Console.ReadLine();
        }

        return int.Parse(stringUserChoice!);
    }

    public void StartGame()
    {
        BowlingGame.LaunchMenu();
    }

    public void Exit()
    {
        Console.WriteLine("A bientôt !");
    }
}