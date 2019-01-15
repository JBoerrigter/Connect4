using Connect4.Properties;
using System;
using System.Windows.Forms;

namespace Connect4
{
    public class Marker : PictureBox
    {
        public int Column { get; private set; }

        public Marker(int column)
        {
            Visible = Visible;
            Column = column;
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Image = Resources.arrows_down;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Image = null;
        }
    }
}
