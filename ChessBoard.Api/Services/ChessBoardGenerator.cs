using System.Text;

namespace ChessBoard.Api.Services
{
    public class ChessBoardGenerator
    {
        private readonly Serilog.ILogger _logger;

        public ChessBoardGenerator(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public string GenerateChessBoardOneLoop(int numberOfRows)
        {
            var chessBoard = new StringBuilder();
            int column = 0;
            for (int i = 1; i <= numberOfRows * numberOfRows; i++)
            {
                chessBoard.Append((column + i) % 2 == 0 ? "0" : "1"); //
                if (i % numberOfRows == 0 && i != 0)
                    if (i % numberOfRows == 0 && i != 0)
                    {
                        chessBoard.AppendLine();
                        if (numberOfRows % 2 == 0)
                            column++;
                    }
            }

            _logger.Information("Generated Board:" + Environment.NewLine + chessBoard.ToString());
            return chessBoard.ToString();
        }

        public string GenerateChessBoardTwoLoops(int numberOfRows)
        {
            var chessBoard = new StringBuilder();
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
                {
                    chessBoard.Append((j + i) % 2 == 0 ? "1" : "0");
                }

                chessBoard.AppendLine();
            }

            _logger.Information("Generated Board:" + Environment.NewLine + chessBoard.ToString());
            return chessBoard.ToString();
        }

        public string GenerateRectangleBoard(int width, int length)
        {
            var chessBoard = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chessBoard.Append((j + i) % 2 == 0 ? "1" : "0");
                }


                chessBoard.AppendLine();
            }

            _logger.Information("Generated Board:" + Environment.NewLine + chessBoard.ToString());
            return chessBoard.ToString();
        }
    }
}