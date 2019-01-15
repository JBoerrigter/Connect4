using System.Drawing;

namespace Connect4
{
    public class Player
    {
        public Color Color { get; set; }

        public Chip GetChip()
        {
            return new Chip(this);
        }
    }
}
