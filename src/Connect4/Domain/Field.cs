using System.Drawing;

namespace Connect4.Domain
{
    public class Field
    {
        public Point Position { get; }
        public Chip Slot { get; private set; }

        public Field(int column, int row)
        {
            Position = new Point(column, row);
        }

        public bool TrySet(Chip chip)
        {
            if (Slot != null) return false;
            Slot = chip;
            return true;
        }
    }
}
