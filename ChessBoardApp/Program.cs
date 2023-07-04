using ChessBoardApp.ChessBoard;
using Serilog;

class Program
{
   public static void Main()
   {

       var logger = new LoggerConfiguration()
           .WriteTo.File("../../../logs.txt")
           .CreateLogger();

        var chessBoardGenerator = new ChessBoardGenerator(logger);
        var inputValidation = new InputValidation(logger);

        var widthInput = ChessBoardDialog.EnterRectangleWidth();

       var widthValidationResult = inputValidation.ValidateInput(widthInput);
        if (!widthValidationResult.IsValid)
        {
            Console.WriteLine(widthValidationResult.ErrorMessage);
            return;
        }

        var width = int.Parse(widthInput);

        var lengthInput = ChessBoardDialog.EnterRectangleLength();

       var lengthValidationResult = inputValidation.ValidateInput(lengthInput);

        if (!lengthValidationResult.IsValid)
        {
            Console.WriteLine(lengthValidationResult.ErrorMessage);
            return;
        }
        var length = int.Parse(lengthInput);

        var generatedChessBoard = chessBoardGenerator.GenerateRectangeBoard(width, length);

        ChessBoardDialog.RectangleMessage(width, length);
        Console.WriteLine(generatedChessBoard);
        Console.ReadLine();


    }
}
