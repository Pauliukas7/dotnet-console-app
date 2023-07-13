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

            var inputValidation = new InputValidation(logger);

            var chessBoardGeneratorService =
                new ChessBoardGeneratorService(inputValidation, logger, _chessBoardRepository, input);
            var successfullyCreated = await chessBoardGeneratorService.Create();

            return successfullyCreated ? Ok() : BadRequest();

        }
    }
}