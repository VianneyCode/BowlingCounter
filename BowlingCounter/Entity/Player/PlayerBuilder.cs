namespace BowlingCounter.Entity.Player;

public class PlayerBuilder
{
    private Player _player { get; set; }

    public PlayerBuilder()
    {
        _player = new Player();
    }

    public void SetPlayerName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("The name of the player cannot be empty");
        }
        _player.Name = name;
    }

    public void AddFrame(Frame.Frame frame)
    {
        ArgumentNullException.ThrowIfNull(frame);

        if (_player.Frames == null)
        {
            _player.Frames = new List<Frame.Frame>();
        }
        
        _player.Frames.Add(frame);
    }

    public Player GetPlayer() => _player;
}