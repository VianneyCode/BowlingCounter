namespace BowlingCounter.Entity.Player;

public class Player
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Frame.Frame> Frames { get; set; }

    public override string ToString()
    {
        return Name;
    }
}