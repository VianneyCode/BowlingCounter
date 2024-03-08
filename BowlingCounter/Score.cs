namespace BowlingCounter
{
    public class Score
    {
        private int _scoreValue;

        public void AddThrowToScore(Throw newThrow, Throw previousThrow)
        {
            if (previousThrow.ThrowType == ThrowType.Strike)
            {
                _scoreValue = (newThrow.FirstThrow * 2) + (newThrow.SecondThrow * 2) ;
            }

            if (previousThrow.ThrowType == ThrowType.Spare)
            {
                _scoreValue = (newThrow.FirstThrow * 2) + newThrow.SecondThrow;
            }
            else
            {
                _scoreValue += newThrow.FirstThrow + newThrow.SecondThrow;
            }
        }

        public int GetScore()
        {
            return _scoreValue;
        }
    }
}
