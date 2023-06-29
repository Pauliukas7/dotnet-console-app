using ChessBoardAssigment;

class Program
{
    static void Main()
    {
        bool tryCodeAgain = true;
        ChessBoardDialog ChessBoardDialog = new();
        ;

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
