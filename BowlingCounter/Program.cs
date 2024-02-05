Console.WriteLine("**************************************");
Console.WriteLine("*** Welcome to the Bowling Counter ***");
Console.WriteLine("**************************************");
Console.WriteLine("\r\n");

Console.WriteLine("MENU : ");
Console.WriteLine("1- Start a new game");
Console.WriteLine("3- Exit");

var choice = Console.ReadLine();

if (choice == "1")
{
    Console.Write("Enter number of players: ");
    int numPlayers = int.Parse(Console.ReadLine());

    int[][] firstThrows = new int[numPlayers][];
    int[][] secondThrows = new int[numPlayers][];

    for (int i = 0; i < numPlayers; i++)
    {
        firstThrows[i] = new int[10];
        secondThrows[i] = new int[10];
    }

    for (int i = 0; i < 10; i++)
    {
        for (int player = 0; player < numPlayers; player++)
        {
            Console.WriteLine("Player " + (player + 1));
            Console.Write("Enter first throw: ");
            firstThrows[player][i] = int.Parse(Console.ReadLine());
            Console.Write("Enter second throw: ");
            secondThrows[player][i] = int.Parse(Console.ReadLine());

            int totalScore = 0;
            for (int j = 0; j <= i; j++)
            {
                totalScore += firstThrows[player][j] + secondThrows[player][j];
                if (j < i && firstThrows[player][j] == 10) // strike
                {
                    totalScore += firstThrows[player][j + 1] + secondThrows[player][j + 1];
                }
                else if (firstThrows[player][j] + secondThrows[player][j] == 10) // spare
                {
                    totalScore += firstThrows[player][j + 1];
                }
            }
            Console.WriteLine("Total score: " + totalScore);

            // Print the throws in a table
            Console.WriteLine("Throws:");
            for (int j = 0; j <= i; j++)
            {
                Console.Write("| " + firstThrows[player][j] + " " + secondThrows[player][j] + " ");
            }
            Console.WriteLine("|");
        }
    }
}
if (choice == "2")
{
    
}
