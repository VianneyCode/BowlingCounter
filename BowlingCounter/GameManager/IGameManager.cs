namespace BowlingCounter.GameManager
{
    public interface IGameManager
    {
        /// <summary>
        /// Plays a game.
        /// </summary>
        void PlayAGame();

        /// <summary>
        /// Displays the high scores.
        /// </summary>
        void DisplayHighScores();
    }
}