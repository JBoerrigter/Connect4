using System.Drawing;

namespace Connect4.Domain
{
    public class Player
    {
        public Color Color { get; }

        public Player(Color color)
        {
            Color = color;
        }

        public override string ToString() => Color.ToString();
    }
}
