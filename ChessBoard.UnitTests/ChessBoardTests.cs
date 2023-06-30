using System.Text;
using Microsoft.Extensions.Logging;

namespace ChessBoardApp.ChessBoard.Tests
{
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

        private class TestLogger<T> : ILogger<T>
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

        private static string GetExpectedChessBoard(int width, int length)
        {
            StringBuilder chessBoard = new();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chessBoard.Append((j + i) % 2 == 0 ? "1" : "0");
                }

                chessBoard.AppendLine();
            }

            return chessBoard.ToString();
        }
    }

    public class ChessBoardDialogTests
    {
        [Fact]
        public void TryAgain_ShouldReturnTrue_WhenUserPresses1()
        {
            // Arrange
            var consoleKeyInfo = new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false);

            // Act
            var result = ChessBoardDialog.TryAgain();

            // Assert
            Assert.True(result);
        }
    }
}
