using BowlingCounter.Entity.Frame;
using BowlingCounter.Entity.Player;
using BowlingCounter.Entity.Throw;

namespace BowlingCounter;

public class BowlingCounter
{
    public void Start()
    {
        var numberOfPlayer = GetNumberOfPlayer();
        var players = GetPlayerList(numberOfPlayer);

        for (var i = 1; i <= 10; i++)
        {
            foreach (var player in players)
            {
                var numberOfPinsDownForTheFirstThrow = GetValidThrowFromUser($"Frame {i} - Player {player.Name} - Enter the number of pins down for the first throw :");
                var numberOfPinsDownForTheSecondThrow = GetValidThrowFromUser($"Frame {i} - Player {player.Name} - Enter the number of pins down for the second throw (enter 0 if strike):");
                    
                var throwBuilder = new ThrowBuilder();
                var firstThrow = throwBuilder.SetNumberOfPinsDown(numberOfPinsDownForTheFirstThrow).GetThrow();
                var secondThrow =  throwBuilder.SetNumberOfPinsDown(numberOfPinsDownForTheSecondThrow).GetThrow();
                    
                var frameBuilder = new FrameBuilder();
                var frame = frameBuilder.SetFrameId(i).SetFirstThrow(firstThrow).SetSecondThrow(secondThrow).GetFrame();

                if (i >= 10 && (frame.IsStrike || frame.IsSpare))
                {
                    var numberOfPinsDownForTheThirdThrow = GetValidThrowFromUser($"Frame {i} - Player {player.Name} - Enter the number of pins down for the third throw:");
                    var thirdThrow = throwBuilder.SetNumberOfPinsDown(numberOfPinsDownForTheThirdThrow).GetThrow(); 
                    frameBuilder = new FrameBuilder(frame);
                    frame = frameBuilder.SetThirdThrow(thirdThrow).GetFrame();
                }
                    
                var playerBuilder = new PlayerBuilder(player);
                playerBuilder.AddFrame(frame);
            }
        }

        DisplayScoreCard(players);
    }

    private void DisplayScoreCard(IEnumerable<Player> players)
    {
        Console.WriteLine("Score card :");
        Console.WriteLine("__________________________");
        foreach (var player in players)
        {
            string.Format("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}", 
                GetDisplayScoreForAFrame(player.Frames[0]), 
                GetDisplayScoreForAFrame(player.Frames[1]),
                GetDisplayScoreForAFrame(player.Frames[2]),
                GetDisplayScoreForAFrame(player.Frames[3]),
                GetDisplayScoreForAFrame(player.Frames[4]),
                GetDisplayScoreForAFrame(player.Frames[5]),
                GetDisplayScoreForAFrame(player.Frames[6]),
                GetDisplayScoreForAFrame(player.Frames[7]),
                GetDisplayScoreForAFrame(player.Frames[8]),
                GetDisplayScoreForAFrame(player.Frames[9]),
                CalculateScoreForAPlayer(player));

            Console.WriteLine("|------------------------|");
        }
    }
    
    private string GetDisplayScoreForAFrame(Frame frame)
    {
        if (frame.ThirdThrow is null)
        {
            if (frame.IsStrike)
                return "X";

            if (frame.IsSpare)
                return $"{frame.FirstThrow.NumberOfPinsDown} - /";

            return $"{frame.FirstThrow.NumberOfPinsDown} - {frame.SecondThrow.NumberOfPinsDown}";
        }

        if(frame.FirstThrow.NumberOfPinsDown == 10 && frame.SecondThrow.NumberOfPinsDown == 10 && frame.ThirdThrow.NumberOfPinsDown == 10)
            return "X - X - X";
            
        if(frame.FirstThrow.NumberOfPinsDown + frame.SecondThrow.NumberOfPinsDown == 10)
            return $"{frame.FirstThrow.NumberOfPinsDown} - / - {frame.ThirdThrow.NumberOfPinsDown}";
            
        if(frame.SecondThrow.NumberOfPinsDown + frame.ThirdThrow.NumberOfPinsDown == 10)
            return $"{frame.FirstThrow.NumberOfPinsDown} - {frame.SecondThrow.NumberOfPinsDown} - /";

        return "";
    }
    
    private int CalculateScoreForAPlayer(Player player)
    {
        var score = 0;
        for (var i = 0; i < player.Frames.Count; i++)
        {
            var frame = player.Frames[i];

            if (frame.ThirdThrow is null)
            {
                if (frame.IsStrike)
                {
                    score += 10 + player.Frames[i + 1].FirstThrow.NumberOfPinsDown + player.Frames[i + 1].SecondThrow.NumberOfPinsDown;
                }
                else if (frame.IsSpare)
                {
                    score += 10 + player.Frames[i + 1].FirstThrow.NumberOfPinsDown;
                }
                else
                {
                    score += frame.FirstThrow.NumberOfPinsDown + frame.SecondThrow.NumberOfPinsDown;
                }
            }
            else
            {
                score += frame.FirstThrow.NumberOfPinsDown + frame.SecondThrow.NumberOfPinsDown + frame.ThirdThrow.NumberOfPinsDown;
            }
            
        }

        return score;
    }

    private int GetValidThrowFromUser(string message)
    {
        var @throw = GetAThrowFromUser(message);
        while (@throw is null)
        {
            @throw = GetAThrowFromUser(message);
        }

        return (int)@throw;
    }

    private int? GetAThrowFromUser(string message)
    {
        Console.WriteLine(message);
        var throwString = Console.ReadLine();
        
        var isUserInputValidInteger = int.TryParse(throwString, out var @throw);

        if (!isUserInputValidInteger)
        {
            Console.WriteLine("The number of pins down is not valid");
            return null;
        }

        if (@throw is < 0 or > 10)
        {
            Console.WriteLine("The number of pins down must be between 0 and 10");
            return null;
        }

        return @throw;
    }

    private IEnumerable<Player> GetPlayerList(int numberOfPlayer)
    {
        var players = new List<Player>();
        for (var i = 0; i < numberOfPlayer; i++)
        {
            Console.WriteLine($"Enter the name of player {i}");
            var playerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("The player name cannot be empty");
            }

            players.Add(new PlayerBuilder().SetPlayerName(playerName).GetPlayer());
        }

        return players;
    }

    private int GetNumberOfPlayer()
    {
        Console.WriteLine("Enter the number of player: ");
        var numberOfPlayerString = Console.ReadLine();

        var isUserInputValidInteger = int.TryParse(numberOfPlayerString, out var numberOfPlayer);

        if (!isUserInputValidInteger)
        {
            Console.WriteLine("The number of player is not valid");
        }

        if (numberOfPlayer <= 0)
        {
            Console.WriteLine("The number of player must be greater than zero");
        }

        return numberOfPlayer;
    }
}