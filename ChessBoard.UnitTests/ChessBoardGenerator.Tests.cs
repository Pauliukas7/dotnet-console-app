using Moq;
using Serilog;



namespace ChessBoardApp.ChessBoard.Tests
{


    public class ChessBoardGeneratorTests
    {

        [Theory]
        [InlineData("1\r\n",1,1)]
        [InlineData("101\r\n010\r\n101\r\n010\r\n", 3,4)]
        [InlineData("1010\r\n0101\r\n1010\r\n0101\r\n", 4,4)]
        [InlineData("1010\r\n0101\r\n1010\r\n0101\r\n1010\r\n0101\r\n", 4,6)]
        public void GenerateRectangleBoard_ShouldReturnCorrectChessBoard(string expected, int width, int length)
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var chessBoardGenerator = new ChessBoardGenerator(loggerMock.Object);


            // Act
           var result = chessBoardGenerator.GenerateRectangeBoard(width, length);

            // Assert
            
            Assert.Contains(expected, result);
        }

       


    }

}