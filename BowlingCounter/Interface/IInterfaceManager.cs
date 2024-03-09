namespace BowlingCounter.Interface
{
    public interface IInterfaceManager
    {
        /// <summary>
        /// Displays the menu.
        /// </summary>
        void DisplayMenu();

        /// <summary>
        /// Gets the player response.
        /// </summary>
        /// <returns></returns>
        string GetPlayerResponse();

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void DisplayMessage(string message);

        /// <summary>
        /// Gets the player number.
        /// </summary>
        /// <returns></returns>
        int GetPlayerNumber();

        /// <summary>
        /// Gets the player turn throw.
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        /// <param name="turnNumber">The turn number.</param>
        /// <returns></returns>
        Throw GetPlayerTurnThrow(string playerName, int turnNumber);

        /// <summary>
        /// Ends the turn.
        /// </summary>
        /// <param name="player">The player.</param>
        void EndTurn(Player player);

        void DisplayHighScores(IEnumerable<Player> highScorePlayers);

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        /// <returns></returns>
        string GetPlayerName();
    }
}
