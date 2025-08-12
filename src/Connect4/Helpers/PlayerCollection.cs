using Connect4.Domain;

namespace Connect4.Helpers
{
    internal class PlayerCollection
    {
        Player[] _Players;
        int _CurrentPlayerIndex = 0;

        /// <summary>
        /// Current player in the game.
        /// </summary>
        public Player CurrentPlayer => _Players[_CurrentPlayerIndex];

        public PlayerCollection(params Player[] players)
        {
            _Players = players;
        }

        public void SwitchPlayer() => _CurrentPlayerIndex = (_CurrentPlayerIndex + 1) % _Players.Length;

    }
}
