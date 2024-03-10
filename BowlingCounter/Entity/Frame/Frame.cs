namespace BowlingCounter.Entity.Frame;

public class Frame
{
    public int Id { get; set; }
    public Throw.Throw FirstThrow { get; set; }
    public Throw.Throw SecondThrow { get; set; }

    public override string ToString()
    {
        return $"Frame n°{Id}";
    }
}