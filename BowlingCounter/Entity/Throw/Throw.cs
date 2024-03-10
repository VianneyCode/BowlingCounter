namespace BowlingCounter.Entity.Throw;

public class Throw
{
    public int NumberOfPinsDown { get; set; }

    public override string ToString()
    {
        return $"This throw has {NumberOfPinsDown} pins down";
    }
}