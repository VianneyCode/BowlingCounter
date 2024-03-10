namespace BowlingCounter.Entity.Frame;

public class FrameBuilder
{
    private Frame _frame { get; set; }

    public FrameBuilder()
    {
        _frame = new Frame();
    }

    public void SetFrameId(int frameId)
    {
        ArgumentNullException.ThrowIfNull(frameId);
        if (frameId <= 0)
        {
            throw new ArgumentException("The frame identifier cannot be smaller than 1");
        }

        _frame.Id = frameId;
    }

    public void SetFirstThrow(Throw.Throw @throw)
    {
        ArgumentNullException.ThrowIfNull(@throw);
        _frame.FirstThrow = @throw;
    }

    public void SetSecondThrow(Throw.Throw @throw)
    {
        ArgumentNullException.ThrowIfNull(@throw);
        _frame.SecondThrow = @throw;
    }

    public Frame GetFrame() => _frame;
}