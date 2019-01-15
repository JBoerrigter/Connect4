using System;
using System.Windows.Forms;

namespace Connect4
{
    public partial class MainForm : Form
    {
        Game _CurrentGame;

        public MainForm()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameContainer.Controls.Clear();
            _CurrentGame = new Game(FieldType.Normal);
            GameContainer.Controls.Add(_CurrentGame.Field);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
