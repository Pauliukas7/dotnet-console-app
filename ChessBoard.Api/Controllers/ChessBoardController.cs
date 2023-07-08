using ChessBoard.Api.Entities;
using ChessBoard.Api.Repositories;
using ChessBoard.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace ChessBoard.Api.Controllers
{
    [ApiController]
    [Route("chessboards")]
    public class ChessBoardController : ControllerBase
    {
        private readonly IChessBoardRepository _chessBoardRepository;

        public ChessBoardController(IChessBoardRepository chessBoardRepository)
        {
            _chessBoardRepository = chessBoardRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ChessBoardEntity>> GetAsync()

        {
            var allChessboards = await _chessBoardRepository.GetAllAsync();
            return allChessboards.OrderBy(chessBoard => chessBoard.GeneratedChessBoard.Length);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChessBoardEntity>> GetChessboard(string id)
        {
            var chessBoard = await _chessBoardRepository.GetAsync(id);
            return chessBoard is not null ? chessBoard : NotFound();
        }


        [HttpPost("{input}")]
        public async Task<ActionResult> CreateAsync([FromRoute] string input)
        {
            var logger = new LoggerConfiguration().CreateLogger();

            var chessBoardGenerator = new ChessBoardGenerator(logger);

            var inputValidation = new InputValidation(logger);
            var inputValidationResult = inputValidation.ValidateInput(input);

            if (inputValidationResult.IsValid)
            {
                var chessBoardLength = int.Parse(input);
                var generatedChessBoard = chessBoardGenerator.GenerateChessBoardOneLoop(chessBoardLength);


                var newId = Guid.NewGuid().ToString();

                var newChessBoard = new ChessBoardEntity() { Id = newId, GeneratedChessBoard = generatedChessBoard };

                await _chessBoardRepository.CreateAsync(newChessBoard);

                return CreatedAtAction(nameof(GetChessboard), new { id = newId }, newChessBoard);
            }
            else
            {
                return BadRequest(inputValidationResult.ErrorMessage);
            }
        }
    }
}