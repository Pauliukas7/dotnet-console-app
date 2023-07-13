using ChessBoard.Api.Entities;
using MongoDB.Driver;

namespace ChessBoard.Api.Repositories
{
    public class ChessBoardRepository : IChessBoardRepository
    {
        private const string CollectionName = "chessboards";
        private readonly IMongoCollection<ChessBoardEntity> _dbCollection;
        private readonly FilterDefinitionBuilder<ChessBoardEntity> filterBuilder = Builders<ChessBoardEntity>.Filter;

        public ChessBoardRepository(IMongoDatabase database)
        {
            _dbCollection = database.GetCollection<ChessBoardEntity>(CollectionName);
        }

        public async Task<IReadOnlyCollection<ChessBoardEntity>> GetAllAsync()
        {
            return await _dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<ChessBoardEntity> GetAsync(string id)
        {
            FilterDefinition<ChessBoardEntity> filter = filterBuilder.Eq(entity => entity.Id, id);

            return await _dbCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateAsync(ChessBoardEntity chessBoard)
        {
            await _dbCollection.InsertOneAsync(chessBoard);
        }
    }
}