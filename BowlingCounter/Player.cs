using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingCounter
{
    public class Player
    {
        public Score Score = new();
        public string PlayerName;

        private readonly List<Throw> _throws = new();

        public Player(string playerName)
        {
            PlayerName = playerName;
        }

        public void PlayATurn(int firstThrow, int secondThrow)
        {
            var previousThrow = _throws.Last();
            var newThrow = new Throw(firstThrow, secondThrow);

            _throws.Add(newThrow);

            Score.AddThrowToScore(newThrow, previousThrow);
        }
    }
}
