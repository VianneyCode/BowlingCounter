using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        int GetPlayerNumber();

        Throw GetPlayerTurnThrow(string playerName);
    }
}
