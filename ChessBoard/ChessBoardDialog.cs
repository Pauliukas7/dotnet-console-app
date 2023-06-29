namespace ChessBoardAssigment
{
    public class ChessBoardDialog
    {
        public ChessBoardDialog() { }

        private int _inputNumberOfRows = 0;

        public void DialogStartMessage()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(
                    "Please enter a number. This will be the number of rows on your chess board: "
                );
                string input = Console.ReadLine();

                validInput = int.TryParse(input, out _inputNumberOfRows) && _inputNumberOfRows > 0;

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            Console.WriteLine("You entered: " + _inputNumberOfRows);
        }

        public bool TryAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Try code again?");
            Console.WriteLine("1 - yes");
            Console.WriteLine("any key - close application");

            ConsoleKeyInfo tryAgainInput = Console.ReadKey(intercept: true);
            return tryAgainInput.KeyChar == '1' ? true : false;
        }

        public int ReturnInputValue()
        {
            return _inputNumberOfRows;
        }

        public void ChessBoardMessage()
        {
            Console.WriteLine(
                "Chessboard where 1 represents white square and 0 represents black square:"
            );
        }
    }
}
