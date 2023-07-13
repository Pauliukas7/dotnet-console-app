using ChessBoard.Api.Entities;

namespace ChessBoard.Api.Repositories
{
    public interface IChessBoardRepository
    {
        Task<IReadOnlyCollection<ChessBoardEntity>> GetAllAsync();
        Task<ChessBoardEntity> GetAsync(string id);
        Task CreateAsync(ChessBoardEntity chessBoard);

    }
}
