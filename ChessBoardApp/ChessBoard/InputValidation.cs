using Serilog;

namespace ChessBoardApp.ChessBoard
{
    public class InputValidation
    {
        private readonly ILogger _logger;

        public InputValidation(ILogger logger)
        {
            _logger = logger;
        }

        public class ValidationResult
        {
            public bool IsValid { get; set; }
            public string? ErrorMessage { get; set; }

            private ValidationResult(bool isValid, string errorMessage)
            {
                IsValid = isValid;
                ErrorMessage = errorMessage;
            }

            public static ValidationResult Success()
            {
                return new ValidationResult(true, null);
            }

            public static ValidationResult Failure(string errorMessage)
            {
                return new ValidationResult(false, errorMessage);
            }
        }

        public ValidationResult ValidateInput(string input)
        {
            bool isValid = int.TryParse(input, out var validInteger) && validInteger > 0;

            if (!isValid)
            {
                string errorMessage = "Invalid input. An integer higher than 0 is required";
                _logger.Error($"Invalid input '{input}'");
                return ValidationResult.Failure(errorMessage);
            }

            return ValidationResult.Success();
        }
    }
}