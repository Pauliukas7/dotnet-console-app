using ChessBoardApp.ChessBoard;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        var loggerChessBoardGenerator = loggerFactory.CreateLogger<ChessBoardGenerator>();
        var loggerChessBoardDialog = loggerFactory.CreateLogger<ChessBoardDialog>();

        string widthInput;
        string lengthInput;

        int width;
        int length;

        var chessBoardGenerator = new ChessBoardGenerator(loggerChessBoardGenerator);
        var chessBoardDialog = new ChessBoardDialog(loggerChessBoardDialog);

        widthInput = ChessBoardDialog.RectangleWidth();
        width = int.Parse(widthInput);

        lengthInput = ChessBoardDialog.RectangleLength();

        length = int.Parse(lengthInput);

        ChessBoardDialog.RectangleMessage(width, length);

        chessBoardGenerator.GenerateRectangeBoard(width, length);
    }
}
