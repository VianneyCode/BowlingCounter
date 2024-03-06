using BowlingCounter.Models;

var menu = new Menu(new List<string>
{
    "Start a new game",
    "Exit"
});

menu.DisplayTitle("Welcome to the Bowling Counter");

menu.DisplayMenu();
var userChoice = menu.UserSelectOption();

switch (userChoice)
{
    case 1:
    {
        menu.StartGame();
        break;
    }
    case 2:
        menu.Exit();
        break;
}