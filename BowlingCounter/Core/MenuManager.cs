using BowlingCounter.Utils;

namespace BowlingCounter;

public class MenuManager
{
    private IEnumerable<string> _menuOptions;

    public MenuManager(IEnumerable<string> menuOptions)
    {
        ArgumentNullException.ThrowIfNull(menuOptions);
        if (!menuOptions.Any())
        {
            throw new ArgumentException("The menu option's list cannot be empty");
        }
        _menuOptions = menuOptions;
    }

    public void DisplayTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException("The title to display cannot be empty");
        }
        
        Console.WriteLine($"*** {title} ***");
    }

    public void DisplayMenu()
    {
        for (var i = 1; i <= _menuOptions.Count(); i++)
        {
            var option = _menuOptions.ElementAt(i);
            
            Console.WriteLine($"{i} - {option}");
        }
    }

    public UserInput GetUserSelection()
    {
        var userInput = new UserInput();
        Console.WriteLine("Enter your choice: ");
        var userChoiceString = Console.ReadLine();
        var isUserInputValidInteger = int.TryParse(userChoiceString, out var userChoice);

        if (!isUserInputValidInteger)
        {
            userInput.UserChoice = null;
            userInput.Error = "Your choice is not valid";
        }

        if (userChoice < 1 && userChoice > _menuOptions.Count())
        {
            userInput.UserChoice = null;
            userInput.Error = "Your choice is not in option's list";
        }

        return userInput;
    }
}