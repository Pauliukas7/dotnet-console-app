namespace ChessBoardApp.ChessBoard
{
    public class InputValidation
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }
       

        public InputValidation(string input)
        {
            IsValid = int.TryParse(input, out var ValidInteger) && ValidInteger > 0;

            ErrorMessage = IsValid ? "" :"Invalid Input";
        }
    }
}