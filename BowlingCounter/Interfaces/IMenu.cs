namespace BowlingCounter.Interfaces;

public interface IMenu
{
    public void DisplayMenu();
    public void DisplayTitle(string message);
    public int UserSelectOption();
    public void StartGame();
    public void Exit();

}