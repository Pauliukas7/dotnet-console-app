using Moq;
using Serilog;
using ChessBoard.Api.Services;
namespace ChessBoard.UnitTests
{
    public class ChessBoardGeneratorTests
    {
        private readonly ChessBoardGenerator _chessBoardGenerator;

        public ChessBoardGeneratorTests()
        {
            Mock<ILogger> loggerMock = new();
            _chessBoardGenerator = new ChessBoardGenerator(loggerMock.Object);
        }

        [Theory]
        [InlineData("1\r\n", 1, 1)]
        [InlineData("101\r\n010\r\n101\r\n010\r\n", 3, 4)]
        [InlineData("1010\r\n0101\r\n1010\r\n0101\r\n", 4, 4)]
        [InlineData("1010\r\n0101\r\n1010\r\n0101\r\n1010\r\n0101\r\n", 4, 6)]
        public void GenerateRectangleBoard_ShouldReturnCorrectChessBoard(string expected, int width, int length)
        {
            // Act
            var result = _chessBoardGenerator.GenerateRectangleBoard(width, length);

            // Assert
            Assert.Contains(expected, result);
        }

        [Theory]
        [InlineData("1\r\n", 1)]
        [InlineData("101\r\n010\r\n101\r\n", 3)]
        [InlineData("1010\r\n0101\r\n1010\r\n0101\r\n", 4)]
        [InlineData("101010\r\n010101\r\n101010\r\n010101\r\n101010\r\n010101\r\n", 6)]
        public void GenerateChessBoardOneLoop_ShouldReturnCorrectChessBoard(string expected, int input)
        {
            // Act
            var result = _chessBoardGenerator.GenerateChessBoardOneLoop(input);

            // Assert
            Assert.Contains(expected, result);
        }

        [Theory]
        [InlineData("1\r\n", 1)]
        [InlineData("101\r\n010\r\n101\r\n", 3)]
        [InlineData("1010\r\n0101\r\n1010\r\n0101\r\n", 4)]
        [InlineData("101010\r\n010101\r\n101010\r\n010101\r\n101010\r\n010101\r\n", 6)]
        public void GenerateChessBoardTwoLoops_ShouldReturnCorrectChessBoard(string expected, int input)
        {
            // Act
            var result = _chessBoardGenerator.GenerateChessBoardTwoLoops(input);

            // Assert
            Assert.Contains(expected, result);
        }
    }
}