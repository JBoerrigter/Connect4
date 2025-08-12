using Connect4.Domain;
using Connect4.Properties;
using System;
using System.Windows.Forms;

namespace Connect4.Rendeering
{
    public class Marker : PictureBox
    {
        public class MarkerClickedEventArgs : EventArgs
        {
            public int Column { get; }
            public int Row { get; }
            public Chip Chip { get; }

            public MarkerClickedEventArgs(int column, int row, Chip chip)
            {
                Column = column;
                Row = row;
                Chip = chip;
            }
        }

        private readonly Game _Game;
        public int Column { get; private set; }

        public event EventHandler<MarkerClickedEventArgs> MarkerClicked;

        public Marker(int column, Game game)
        {
            _Game = game;
            Column = column;
            Visible = Visible;
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

        protected override void OnClick(EventArgs e)
        {
            int row = _Game.Drop(Column);
            if (row == -1) return;

            Chip chip = _Game.GameField[Column, row].Slot;
            MarkerClicked?.Invoke(this, new MarkerClickedEventArgs(Column, row, chip));
        }
    }
}
