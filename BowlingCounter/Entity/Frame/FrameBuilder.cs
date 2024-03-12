namespace BowlingCounter.Entity.Frame;

public class FrameBuilder
{
    private Frame _frame { get; set; }

    public FrameBuilder(Frame? frame = null)
    {
        _frame = frame ?? new Frame();
    }

    public FrameBuilder SetFrameId(int frameId)
    {
        ArgumentNullException.ThrowIfNull(frameId);
        if (frameId <= 0)
        {
            throw new ArgumentException("The frame identifier cannot be smaller than 1");
        }

        _frame.Id = frameId;

        return this;
    }

    public FrameBuilder SetFirstThrow(Throw.Throw @throw)
    {
        ArgumentNullException.ThrowIfNull(@throw);
        _frame.FirstThrow = @throw;
        
        return this;
    }

    public FrameBuilder SetSecondThrow(Throw.Throw @throw)
    {
        ArgumentNullException.ThrowIfNull(@throw);
        _frame.SecondThrow = @throw;

        return this;
    }

    public FrameBuilder SetThirdThrow(Throw.Throw @throw)
    {
        ArgumentNullException.ThrowIfNull(@throw);
        _frame.ThirdThrow = @throw;

        return this;
    }

    public Frame GetFrame() => _frame;
}