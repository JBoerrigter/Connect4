using Connect4.Domain;
using System;

namespace Connect4.Helpers
{
    public static class FieldFactory
    {
        public static Field[,] Create(FieldType fieldType)
        {
            Field[,] gameField;
            switch (fieldType)
            {
                case FieldType.Normal: gameField = new Field[7, 6]; break;
                case FieldType.Small: gameField = new Field[5, 5]; break;
                default: throw new ArgumentException("Invalid field type");
            }

            InitializeFields(gameField);

            return gameField;
        }

        private static void InitializeFields(Field[,] gameField)
        {
            int columns = gameField.GetLength(0);
            int rows = gameField.GetLength(1);

            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    gameField[column, row] = new Field(column, row);
                }
            }
        }
    }
}
