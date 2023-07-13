using ChessBoard.Api.Entities;
using ChessBoard.Api.Repositories;
using System.Text;

namespace ChessBoard.Api.Services
{
    public class ChessBoardGeneratorService
    {
        private Serilog.ILogger _logger;
        private IChessBoardRepository _chessBoardRepository;
        private InputValidation _inputValidation;
        private string _input;


        public ChessBoardGeneratorService(InputValidation inputValidation, Serilog.ILogger logger,
            IChessBoardRepository chessBoardRepository, string input
        )
        {
            _logger = logger;
            _chessBoardRepository = chessBoardRepository;
            _inputValidation = inputValidation;
            _input = input;

        }

        public async Task<bool> Create()
        {

            var inputValidationResult = _inputValidation.ValidateInput(_input);

            if (inputValidationResult.IsValid)
            {
                var chessBoardLength = int.Parse(_input);

                var generatedChessBoard = GenerateChessBoardOneLoop(chessBoardLength);

                var newId = Guid.NewGuid().ToString();

                var newChessBoard = new ChessBoardEntity() { Id = newId, GeneratedChessBoard = generatedChessBoard };

                await _chessBoardRepository.CreateAsync(newChessBoard);

                return true;
            }
            else
            {
                return false;
            }
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


    }
}