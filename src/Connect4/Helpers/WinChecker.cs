using Connect4.Domain;
using System.Drawing;

namespace Connect4.Helpers
{
    public class WinChecker
    {
        private const int FieldsToWin = 4;
        private readonly Game _Game;
        private readonly Point[] _Directions;

        public WinChecker(Game game)
        {
            _Game = game;
            _Directions = new Point[] {
                new Point(0, -1), // top
                new Point(0, 1), // bottom
                new Point(-1, 0), // left
                new Point(1, 0), // right
                new Point(1, -1), // top right
                new Point(-1, -1), // top left
                new Point(1, 1), // bottom right
                new Point(-1, 1), // bottom left
            };
        }

        public bool Check(int column, int row)
        {
            Player current = _Game.GameField[column, row].Slot.Owner;

            foreach (Point direction in _Directions)
            {
                int winCounter = FieldsToWin - 1;

                for (int nextStep = 1; nextStep < FieldsToWin; nextStep++)
                {
                    int columnToCheck = column + (nextStep * direction.X);
                    int rowToCheck = row + (nextStep * direction.Y);

                    if (IsSlotOwnedBy(columnToCheck, rowToCheck, current)) winCounter--;
                    else break;
                }

                if (winCounter == 0) return true;
            }

            return false;
        }

        private bool IsSlotOwnedBy(int column, int row, Player owner)
        {
            if (column < 0 || column >= _Game.GameField.GetLength(0) ||
                row < 0 || row >= _Game.GameField.GetLength(1)) return false;
            return _Game.GameField[column, row].Slot?.Owner == owner;
        }
    }
}

