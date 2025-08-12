using Connect4.Rendeering;
using System.Windows.Forms;

namespace Connect4.Rendering
{
    public class GameRenderer
    {
        public static TableLayoutPanel Render(Domain.Game currentGame)
        {
            int columnCount = currentGame.GameField.GetLength(0);
            int rowCount = currentGame.GameField.GetLength(1);

            TableLayoutPanel renderedControl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = rowCount + 1,
                ColumnCount = columnCount,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            for (int column = 0; column < columnCount; column++)
            {
                renderedControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

                Marker marker = new Marker(column, currentGame);
                marker.MarkerClicked += (s, e) =>
                {
                    Control renderedChip = ChipRenderer.Render(e.Chip);
                    renderedControl.Controls.Add(renderedChip, e.Column, renderedControl.RowCount - 1 - e.Row);
                };
                renderedControl.Controls.Add(marker, column, 0);
            }

            for (int row = 0; row <= rowCount; row++)
            {
                renderedControl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            }

            return renderedControl;
        }

    }
}
