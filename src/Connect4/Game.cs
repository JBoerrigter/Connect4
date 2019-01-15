using System.Drawing;
using System.Windows.Forms;

namespace Connect4
{
    public class Game
    {
        private Player _FirstPlayer;
        private Player _SecondPlayer;

        /// <summary>
        /// The player that is able to drop the next chip
        /// </summary>
        public Player CurrentPlayer { get; private set; }

        /// <summary>
        /// The field where the action happens
        /// 
        /// </summary>
        public Field Field { get; private set; }

        /// <summary>
        /// Initialize a game instance
        /// </summary>
        /// <param name="type">
        /// The kind of game, that will be initialized
        /// </param>
        public Game(FieldType type)
        {
            Field = new Field(type);
            Field.Click += Field_Clicked;

            _FirstPlayer = new Player() { Color = Color.Yellow };
            _SecondPlayer = new Player() { Color = Color.Red };

            CurrentPlayer = _FirstPlayer;
        }

        /// <summary>
        /// Drops a chip in the color of the current player
        /// in the selected column if possible.
        /// If is success the current player changes
        /// </summary>
        private void Field_Clicked(object sender, System.EventArgs e)
        {
            if (e is ControlEventArgs args)
                if (args.Control is Marker marker)
                {
                    Chip c = CurrentPlayer.GetChip();

                    if (Field.Drop(c, marker.Column))
                    {
                        if (Field.Check(c))
                            Field.Finish();
                        else
                            SwitchPlayer();
                    }

                }
        }

        /// <summary>
        /// Changes the current player
        /// </summary>
        private void SwitchPlayer()
        {
            if (CurrentPlayer.Equals(_FirstPlayer))
                CurrentPlayer = _SecondPlayer;
            else
                CurrentPlayer = _FirstPlayer;
        }
    }
}
