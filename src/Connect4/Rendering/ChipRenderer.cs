using Connect4.Domain;
using System.Windows.Forms;

namespace Connect4.Rendering
{
    public static class ChipRenderer
    {
        public static Panel Render(Chip chip)
        {
            return new Panel
            {
                BackColor = chip.Owner.Color,
                Dock = DockStyle.Fill,
                Tag = chip
            };
        }
    }
}
