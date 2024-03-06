namespace BowlingCounter.Models;

public static class DisplayerManager
{
    public static void ClearLines(int numberOfLine)
    {
        for (var i = 0; i < numberOfLine; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}