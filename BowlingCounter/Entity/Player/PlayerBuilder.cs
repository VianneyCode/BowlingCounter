namespace BowlingCounter.Entity.Player;

public class PlayerBuilder
{
    private Player _player { get; set; }

    public PlayerBuilder(Player? player = null)
    {
        _player = player ?? new Player();
    }

    public PlayerBuilder SetPlayerName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("The name of the player cannot be empty");
        }
        _player.Name = name;
        
        return this;
    }

    public PlayerBuilder AddFrame(Frame.Frame frame)
    {
        ArgumentNullException.ThrowIfNull(frame);

        if (_player.Frames == null)
        {
            _player.Frames = new List<Frame.Frame>();
        }
        
        _player.Frames.Add(frame);
        return this;
    }

    public Player GetPlayer() => _player;
}