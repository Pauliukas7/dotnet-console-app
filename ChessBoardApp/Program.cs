using ChessBoardApp.ChessBoard;
using Microsoft.Extensions.Logging;

class Program
{
   public static void Main()
    {
       

      
        var chessBoardGenerator = new ChessBoardGenerator();

        var widthInput = ChessBoardDialog.EnterRectangleWidth();
        var widthInputValidation = new InputValidation(widthInput);
        if (!widthInputValidation.IsValid)
        {
            Console.WriteLine(widthInputValidation.ErrorMessage);
            return;
        }

        var width = int.Parse(widthInput);

        var lengthInput = ChessBoardDialog.EnterRectangleLength();
        var lengthInputValidation = new InputValidation(lengthInput);
        if (!lengthInputValidation.IsValid)
        {
            Console.WriteLine(lengthInputValidation.ErrorMessage);
            return;
        }
        var length = int.Parse(lengthInput);

        var generatedChessBoard = chessBoardGenerator.GenerateRectangeBoard(width, length);

        ChessBoardDialog.RectangleMessage(width, length);
        Console.WriteLine(generatedChessBoard);
        Console.ReadLine();


    }
}
