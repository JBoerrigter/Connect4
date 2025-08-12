using Connect4.Helpers;
using System;
using System.Drawing;

namespace Connect4.Domain
{
    public class Game
    {
        WinChecker _WinChecker;
        PlayerCollection _Players;

        /// <summary>
        /// Current Field where the action happens.
        /// </summary>
        public Field[,] GameField { get; }

        public event EventHandler<Player> GameOver;

        public Game(FieldType fieldType)
        {
            GameField = FieldFactory.Create(fieldType);
            _WinChecker = new WinChecker(this);
            _Players = new PlayerCollection(
                new Player(Color.Yellow),
                new Player(Color.Red));
        }

        public int Drop(int column)
        {
            Chip chip = new Chip(_Players.CurrentPlayer);
            int rowCount = GameField.GetLength(1);

            for (int row = 0; row < rowCount; row++)
            {
                if (GameField[column, row].TrySet(chip))
                {
                    if (_WinChecker.Check(column, row))
                    {
                        GameOver?.Invoke(this, _Players.CurrentPlayer);
                    }
                    else
                    {
                        _Players.SwitchPlayer();
                    }

                    return row;
                }
            }

            return -1;
        }
    }
}

