using System.Text;
using Microsoft.Extensions.Logging;


namespace ChessBoardApp.ChessBoard.Tests
{


    public class ChessBoardGeneratorTests
    {
        
        public void GenerateRectangleBoard_ShouldLogCorrectChessBoard()
        {
            // Arrange
            var chessBoardGenerator = new ChessBoardGenerator();
            int width = 4;
            int length = 6;

            // Act
            chessBoardGenerator.GenerateRectangeBoard(width, length);

            // Assert
            string expectedChessBoard = GetExpectedChessBoard(width, length);
            Assert.Contains(expectedChessBoard, string.Join("\r\n", logger.LoggedMessages));
        }

        private static string GetExpectedChessBoard(int width, int length)
        {
            StringBuilder chessBoard = new();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chessBoard.Append((j + i) % 2 == 0 ? "2" : "0");
                }

                chessBoard.AppendLine();
            }

            return chessBoard.ToString();
        }
    }

}