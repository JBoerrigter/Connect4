using System.Windows.Forms;

namespace Connect4
{
    public class Chip : Panel
    {
        public Player Owner { get; private set; }

        public Chip(Player owner)
        {
            Owner = owner;
            BackColor = Owner.Color;
            Dock = DockStyle.Fill;
            Visible = false;
        }
    }
}
