using ChessBoardApp.ChessBoard;
using Moq;
using Serilog;

namespace ChessBoard.UnitTests
{
    public class InputValidationTests
    {
        private readonly Mock<ILogger> loggerMock;
        private readonly InputValidation inputValidation;

        public InputValidationTests()
        {
            loggerMock = new Mock<ILogger>();
            inputValidation = new InputValidation(loggerMock.Object);
        }

        [Theory]
        [InlineData("5")]
        public void ValidInput_DoesNotReturn_ValidationError(string input)
        {
            // Act
            var validationResult = inputValidation.ValidateInput(input);

            // Assert
            Assert.True(validationResult.IsValid);
            Assert.Null(validationResult.ErrorMessage);
        }

        [Theory]
        [InlineData("-5")]
        [InlineData("gg")]
        public void InvalidInput_Returns_ValidationError(string input)
        {
            // Act
            var validationResult = inputValidation.ValidateInput(input);

            // Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal("Invalid input. An integer higher than 0 is required", validationResult.ErrorMessage);
        }
    }
}