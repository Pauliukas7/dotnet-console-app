namespace ChessBoardAssigment
{
    public class ChessBoard
    {
        public static void GenerateChessBoardOneLoop(int numberOfRows)
        {
            int column = 0;
            for (int i = 1; i <= numberOfRows * numberOfRows; i++)
            {
                Console.Write((column + i) % 2 == 0 ? "0" : "1"); //
                if (i % numberOfRows == 0 && i != 0)
                {
                    Console.WriteLine();
                    if (numberOfRows % 2 == 0)
                        column++;
                }
            }
        }

        public static void GenerateChessBoardTwoLoops(int numberOfRows)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
                {
                    Console.Write((j + i) % 2 == 0 ? "1" : "0");
                }
                Console.WriteLine();
            }
        }
    }
}
