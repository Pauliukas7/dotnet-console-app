namespace ChessBoardApp.ChessBoard
{
    public class InputValidation
    {
        private static int _rectangleWidth = 0;
        private static int _rectangleLength = 0;
        private static int _inputNumberOfRows = 0;

        public static bool ValidChessBoardRowsInput(string input)
        {
            bool validInput = int.TryParse(input, out _inputNumberOfRows) && _inputNumberOfRows > 0;
            return validInput;
        }

        public static bool ValidRectangleWidth(string input)
        {
            bool validInput = int.TryParse(input, out _rectangleWidth) && _rectangleWidth > 0;
            return validInput;
        }

        public static bool ValidRectangleLength(string input)
        {
            bool validInput = int.TryParse(input, out _rectangleLength) && _rectangleLength > 0;
            return validInput;
        }

        public static int RectangleWidth()
        {
            return _rectangleWidth;
        }

        public static int RectangleLength()
        {
            return _rectangleLength;
        }

        public static int ChessBoardNumberOfRows()
        {
            return _inputNumberOfRows;
        }
    }
}
