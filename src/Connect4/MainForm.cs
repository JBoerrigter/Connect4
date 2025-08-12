using Connect4.Helpers;
using Connect4.Rendering;
using System;
using System.Windows.Forms;

namespace Connect4
{
    public partial class MainForm : Form
    {
        //Game _CurrentGame;
        Domain.Game _CurrentGame;

        public MainForm()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameContainer.Controls.Clear();
            _CurrentGame = new Domain.Game(FieldType.Normal);
            _CurrentGame.GameOver += (s, player) =>
            {
                MessageBox.Show(
                    text: $"Player {player} wins!",
                    caption: "Game Over",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information);
                GameContainer.Controls.Clear();
            };
            //_CurrentGame = new Game(FieldType.Normal);
            GameContainer.Controls.Add(GameRenderer.Render(_CurrentGame));
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
