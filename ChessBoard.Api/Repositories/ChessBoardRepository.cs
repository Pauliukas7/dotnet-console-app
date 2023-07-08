using ChessBoard.Api.Entities;
using MongoDB.Driver;

namespace ChessBoard.Api.Repositories
{
    public class ChessBoardRepository : IChessBoardRepository
    {
        private const string _collectionName = "chessboards";
        private readonly IMongoCollection<ChessBoardEntity> _dbCollection;
        private readonly FilterDefinitionBuilder<ChessBoardEntity> filterBuilder = Builders<ChessBoardEntity>.Filter;

        public ChessBoardRepository(IMongoDatabase database)
        {
            _dbCollection = database.GetCollection<ChessBoardEntity>(_collectionName);
        }

        public async Task<IReadOnlyCollection<ChessBoardEntity>> GetAllAsync()
        {
            return await _dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<ChessBoardEntity> GetAsync(string id)
        {
            FilterDefinition<ChessBoardEntity> filter = filterBuilder.Eq(entity => entity.Id, id);

            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(ChessBoardEntity chessBoard)
        {
            await _dbCollection.InsertOneAsync(chessBoard);
        }
    }
}