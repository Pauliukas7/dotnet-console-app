namespace Assignment
{
    public class ChessBoardDialog
    {
        public ChessBoardDialog() { }

        private int _inputNumberOfRows = 0;

        public void GameStart()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(
                    "Please enter a number. This will be the number of rows on your chess board: "
                );
                string input = Console.ReadLine();

                validInput = int.TryParse(input, out _inputNumberOfRows);

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            Console.WriteLine("You entered: " + _inputNumberOfRows);
        }
    }
}
