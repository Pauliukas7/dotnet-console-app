using ChessBoardApp.ChessBoard;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main()
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        var loggerChessBoardGenerator = loggerFactory.CreateLogger<ChessBoardGenerator>();
        var loggerChessBoardDialog = loggerFactory.CreateLogger<ChessBoardDialog>();

        var tryCodeAgain = true;

        string widthInput;
        string lengthInput;

        int width;
        int length;

        while (tryCodeAgain)
        {
            var chessBoardGenerator = new ChessBoardGenerator(loggerChessBoardGenerator);
            var chessBoardDialog = new ChessBoardDialog(loggerChessBoardDialog);

            widthInput = ChessBoardDialog.RectangleWidth();
            while (!InputValidation.ValidRectangleWidth(widthInput))
            {
                chessBoardDialog.InvalidNumberInput();
                widthInput = ChessBoardDialog.RectangleWidth();
            }
            width = int.Parse(widthInput);

            lengthInput = ChessBoardDialog.RectangleLength();
            while (!InputValidation.ValidRectangleLength(lengthInput))
            {
                chessBoardDialog.InvalidNumberInput();
                lengthInput = ChessBoardDialog.RectangleWidth();
            }
            length = int.Parse(lengthInput);

            ChessBoardDialog.RectangleMessage(width, length);

            chessBoardGenerator.GenerateRectangeBoard(width, length);

            tryCodeAgain = ChessBoardDialog.TryAgain();
        }
    }
}
