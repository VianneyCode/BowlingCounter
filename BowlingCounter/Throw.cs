namespace BowlingCounter
{
    public class Throw
    {
        public int FirstThrow;
        public int SecondThrow;

        public ThrowType ThrowType
        {
            get
            {
                if (FirstThrow == 10)
                    return ThrowType.Strike;
                return FirstThrow + SecondThrow == 10 ? ThrowType.Spare : ThrowType.Normal;
            }
        }

        public Throw(int firstThrow, int secondThrow)
        {
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
        }
    }
}