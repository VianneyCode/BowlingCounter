namespace BowlingCounter.Entity.Throw;

public class ThrowBuilder
{
    private Throw _throw { get; set; }

    public ThrowBuilder()
    {
        _throw = new Throw();
    }

    public ThrowBuilder SetNumberOfPinsDown(int pinsDown)
    {
        ArgumentNullException.ThrowIfNull(pinsDown);
        if (pinsDown < 0)
        {
            throw new ArgumentException("the number of pins down for a throw cannot be less than 0");
        }

        _throw.NumberOfPinsDown = pinsDown;
        return this;
    }
    
    public Throw GetThrow() => _throw;

}