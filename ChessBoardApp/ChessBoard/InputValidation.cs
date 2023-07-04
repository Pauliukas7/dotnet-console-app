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
            public string ErrorMessage { get; set; }

            public ValidationResult(bool isValid, string errorMessage)
            {
                IsValid = isValid;
                ErrorMessage = errorMessage;
            }
        }


        public ValidationResult ValidateInput(string input)
        {
            bool isValid = int.TryParse(input, out var validInteger) && validInteger > 0;

            if (!isValid)
            {
                string errorMessage = "Invalid input. An integer higher than 0 is required";
                _logger.Error($"Invalid input '{input}'");
                return new ValidationResult(false, errorMessage);
            }

            return new ValidationResult(true, null);
        }
    }
}