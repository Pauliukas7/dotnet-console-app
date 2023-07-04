using Microsoft.Extensions.Logging;

namespace ChessBoardApp.ChessBoard
{

    public class ChessBoardDialog
    {

        public static string EnterRectangleWidth()
        {
            Console.Write("Please enter rectangle width: ");
            return Console.ReadLine();
        }

        public static string EnterRectangleLength()
        {
            Console.Write("Please enter rectangle length: ");
            return Console.ReadLine();
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


    }
}
