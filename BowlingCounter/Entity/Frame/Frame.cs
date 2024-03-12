namespace BowlingCounter.Entity.Frame;

public class Frame
{
    public int Id { get; set; }
    public Throw.Throw FirstThrow { get; set; }
    public Throw.Throw SecondThrow { get; set; }
    public Throw.Throw? ThirdThrow { get; set; }

    public bool IsStrike => FirstThrow.NumberOfPinsDown == 10;
    public bool IsSpare => FirstThrow.NumberOfPinsDown + SecondThrow.NumberOfPinsDown == 10;
    
    public override string ToString()
    {
        return $"Frame n°{Id}";
    }
}