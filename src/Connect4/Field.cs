using System.Windows.Forms;

namespace Connect4
{
    public class Field : TableLayoutPanel
    {
        private Direction[] _Directions;

        /// <summary>
        /// Creates a new Instance of the visible game field
        /// </summary>
        /// <param name="fieldType">
        /// Defines the size of the field
        /// </param>
        public Field(FieldType fieldType)
        {
            _Directions = new Direction[] {
                new Direction(0, 1), // bottom
                new Direction(1, 1), // bottom right
                new Direction(1, 0), // right
                new Direction(1, -1) // top right
            };
            switch (fieldType)
            {
                case FieldType.Normal:
                    InitializeField(6, 7);
                    break;
                case FieldType.Small:
                    InitializeField(5, 5);
                    break;
            }
            Dock = DockStyle.Fill;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }

        /// <summary>
        /// Initialize the visible field
        /// </summary>
        /// <param name="rows">
        /// Number of rows the game will have
        /// </param>
        /// <param name="cols">
        /// Number of columns the game will have
        /// </param>
        private void InitializeField(int rows, int cols)
        {
            RowStyles.Clear();
            ColumnStyles.Clear();

            RowCount = rows + 1;
            ColumnCount = cols;

            for (int i = 0; i <= rows; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            }
            for (int i = 0; i < cols; i++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                Marker marker = new Marker(i);
                marker.MouseClick += Marker_Clicked;
                Controls.Add(marker, i, 0);
            }
        }

        /// <summary>
        /// visualize the winning chips
        /// </summary>
        public void Finish()
        {
            MessageBox.Show("You won!");
            // TODO: highlight the winning chips
        }

        /// <summary>
        /// Checks for a winner
        /// </summary>
        public bool Check(Chip current)
        {
            TableLayoutPanelCellPosition currentPos = GetPositionFromControl(current);

            foreach (Direction direction in _Directions)
            {
                for (int side = -1; side <= 1; side += 2)
                {
                    int winCounter = 0;
                    for (int counter = -3; counter <= 3; counter++)
                    {
                        int col = currentPos.Column + (counter * (direction.X * side));
                        int row = currentPos.Row + (counter * (direction.Y * side));

                        if (HasSameOwner(col, row, current.Owner))
                            winCounter++;
                        else if (counter < 0)
                            continue;
                        else
                            break;
                    }
                    if (winCounter == 4)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// checks if the chip at a given point has the same owner
        /// </summary>
        /// <param name="column">
        /// the column to check
        /// </param>
        /// <param name="row">
        /// the row to check
        /// </param>
        /// <param name="owner">
        /// the owner that need to be equal
        /// </param>
        private bool HasSameOwner(int column, int row, Player owner)
        {
            if (column >= 0 && row >= 0 &&
                GetControlFromPosition(column, row) is Chip chipToCheck &&
                chipToCheck.Owner.Equals(owner))
                return true;
            return false;
        }

        /// <summary>
        /// Event occurs when a marker is clicked 
        /// </summary>
        private void Marker_Clicked(object sender, MouseEventArgs e)
        {
            if (sender is Marker marker)
                OnClick(new ControlEventArgs(marker));
        }

        /// <summary>
        /// Place a chip on the field in a specific row
        /// </summary>
        public bool Drop(Chip chip, int column)
        {

            int possibleRow = GetPossibleRow(column);

            if (possibleRow >= 0)
            {
                Controls.Add(chip, column, possibleRow);
                chip.Visible = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// get the minimal row number that is possible to 
        /// drop a chip
        /// </summary>
        private int GetPossibleRow(int column)
        {
            for (int i = RowCount - 1; i > 0; i--)
            {
                // no control => space for current chip
                if (GetControlFromPosition(column, i) == null)
                    return i;
            }

            // if there is no possible row 
            return -1;
        }
    }
}
