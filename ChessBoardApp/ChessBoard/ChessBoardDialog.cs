using Microsoft.Extensions.Logging;

namespace ChessBoardApp.ChessBoard
{
    public class ChessBoardDialog
    {
        private readonly ILogger<ChessBoardDialog> _logger;

        public ChessBoardDialog(ILogger<ChessBoardDialog> logger)
        {
            _logger = logger;
        }

        public static string ChessBoardNumberOfRows()
        {
            Console.Write(
                "Please enter a number. This will be the number of rows on your chess board: "
            );
            string input = Console.ReadLine();
            return input;
        }

        public static string RectangleWidth()
        {
            Console.Write("Please enter rectangle width: ");
            string inputWidth = Console.ReadLine();
            return inputWidth;
        }

        public static string RectangleLength()
        {
            Console.Write("Please enter rectangle length: ");
            string inputLength = Console.ReadLine();
            return inputLength;
        }

        public static bool TryAgain()
        {
            // Console.WriteLine();
            Console.WriteLine("Try code again?");
            Console.WriteLine("1 - yes");
            Console.WriteLine("any key - close application");

            ConsoleKeyInfo tryAgainInput = Console.ReadKey(intercept: true);

            return tryAgainInput.KeyChar == '1';
        }

        public static void ChessBoardMessage()
        {
            Console.WriteLine(
                "Chessboard where 1 represents white square and 0 represents black square:"
            );
        }

        public static void RectangleMessage(int width, int length)
        {
            Console.WriteLine(
                $"Rectangle board with your provided width {width} and length {length}"
            );
        }

        public void InvalidNumberInput()
        {
            Console.WriteLine("Invalid input. Please provide a valid number");
            _logger.LogError("Invalid number input occurred");
        }
    }
}
