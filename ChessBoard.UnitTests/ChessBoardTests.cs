using System.Text;
using Microsoft.Extensions.Logging;
using Moq;

namespace ChessBoardApp.ChessBoard.Tests
{
    class TestLogger<T> : ILogger<T>
    {
        public List<string> LoggedMessages { get; } = new();

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter
        )
        {
            string logMessage = formatter(state, exception);
            LoggedMessages.Add(logMessage);
        }
    }

    public class ChessBoardGeneratorTests
    {
        [Fact]
        public void GenerateRectangleBoard_ShouldLogCorrectChessBoard()
        {
            // Arrange
            var logger = new TestLogger<ChessBoardGenerator>();
            var chessBoardGenerator = new ChessBoardGenerator(logger);
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

    public class ChessBoardDialogTests
    {
        [Fact]
        public void ChessBoardMessage_ShouldWriteExpectedMessage()
        {
            // Arrange
            var logger = new TestLogger<ChessBoardDialog>();
            var chessBoardDialog = new ChessBoardDialog(logger);

            // Act
            chessBoardDialog.InvalidNumberInput();

            string expectedLoggedMessage = "Invalid number input occurredd";
            // Assert

            Assert.Contains(expectedLoggedMessage, string.Join("\r\n", logger.LoggedMessages));
        }
    }
}
