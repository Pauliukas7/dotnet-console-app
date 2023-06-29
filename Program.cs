using ChessBoardAssigment;

class Program
{
    static void Main()
    {
        var tryCodeAgain = true;

        while (tryCodeAgain)
        {
            ChessBoardDialog.DialogStartMessage();

            int inputNumberOfRows = ChessBoardDialog.ReturnInputValue();

            ChessBoardDialog.ChessBoardMessage();

            ChessBoard.GenerateChessBoardOneLoop(inputNumberOfRows);

            tryCodeAgain = ChessBoardDialog.TryAgain();
        }
    }
}
