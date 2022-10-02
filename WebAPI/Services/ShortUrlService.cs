using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web_API.Models;

namespace Web_API.Services
{
    public class ShortUrlService
    {
        private readonly IMongoCollection<ShortUrl> _shortUrlCollection;

        public ShortUrlService(
            IOptions<UrlCollectionDatabaseSettings> urlCollectionDatabaseSettings)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);

            var mongoDatabase = mongoClient.GetDatabase(mongoUrl.DatabaseName);

            _shortUrlCollection = mongoDatabase.GetCollection<ShortUrl>(
               "ShortUrls");
        }

        public async Task<List<ShortUrl>> GetAsync() =>
            await _shortUrlCollection.Find(_ => true).ToListAsync();

        public async Task<ShortUrl?> GetAsync(string id) =>
            await _shortUrlCollection.Find(x => x.Hash == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ShortUrl newShortUrl) =>
            await _shortUrlCollection.InsertOneAsync(newShortUrl);

        public async Task RemoveAsync(string id) =>
            await _shortUrlCollection.DeleteOneAsync(x => x.Hash == id);
    }
}
