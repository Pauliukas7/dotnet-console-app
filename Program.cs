using ChessBoardAssigment;

class Program
{
    static void Main()
    {
        bool tryCodeAgain = true;
        ChessBoardDialog ChessBoardDialog = new();
        ChessBoard ChessBoard = new();

        while (tryCodeAgain)
        {
            ChessBoardDialog.DialogStartMessage();

            int inputNumberOfRows = ChessBoardDialog.ReturnInputValue();

            ChessBoard.GenerateChessBoardOneLoop(inputNumberOfRows);
            tryCodeAgain = ChessBoardDialog.TryAgain();
        }
    }
}
