using BowlingCounter.Interfaces;

namespace BowlingCounter.Models;

public class PlayerGame : IPlayerGame
{
    private int[] rolls = new int[21];
    private int currentRoll = 0;
    public string Name { get; private set; }

    public PlayerGame(string name)
    {
        Name = name;
    }
    

    public void Roll(int pins)
    {
        if (currentRoll >= rolls.Length)
        {
            Console.WriteLine("/!\\ Cannot roll after game is over");
        }
        else
        {
            rolls[currentRoll++] = pins;
        }
    }

    public int Score()
    {
        var score = 0;
        var frameIndex = 0;
        for (var frame = 0; frame < 10; frame++)
        {
            if (IsStrike(frameIndex)) // strike
            {
                score += 10 + StrikeBonus(frameIndex);
                frameIndex++;
            }
            else if (IsSpare(frameIndex)) // spare
            {
                score += 10 + SpareBonus(frameIndex);
                frameIndex += 2;
            }
            else
            {
                score += SumOfBallsInFrame(frameIndex);
                frameIndex += 2;
            }
        }
        return score;
    }

    private bool IsStrike(int frameIndex)
    {
        return rolls[frameIndex] == 10;
    }

    private int SumOfBallsInFrame(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1];
    }

    private int SpareBonus(int frameIndex)
    {
        return rolls[frameIndex + 2];
    }

    private int StrikeBonus(int frameIndex)
    {
        return rolls[frameIndex + 1] + rolls[frameIndex + 2];
    }

    private bool IsSpare(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    } 
}