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
            Console.WriteLine("Try code again? \n1 - yes \nany key - close application");
            ConsoleKeyInfo tryAgainInput = Console.ReadKey(intercept: true);
            if (tryAgainInput.KeyChar == '1')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ReturnInputValue()
        {
            return _inputNumberOfRows;
        }
    }
}
