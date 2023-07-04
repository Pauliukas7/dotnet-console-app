using Moq;
using Serilog;



namespace ChessBoardApp.ChessBoard.Tests
{


    public class InputValidationTests
    {

        

        [Theory]
        [InlineData("5")]
        [InlineData("gg")]
        [InlineData("-5")]
        public void ValidateInput_ShouldReturnCorrectObject(string input)
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var inputValidation = new InputValidation(loggerMock.Object);


            // Act
            var validationResult = inputValidation.ValidateInput(input);

            // Assert

            if (int.TryParse(input, out var x) && x > 0)
            {
                Assert.True(validationResult.IsValid);
                Assert.Null(validationResult.ErrorMessage);
            }
            else
            {
                Assert.False(validationResult.IsValid);
                Assert.Equal("Invalid input. An integer higher than 0 is required", validationResult.ErrorMessage);
            }
        }


    }

}