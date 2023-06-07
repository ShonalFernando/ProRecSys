using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shoppinz.Models;
using Shoppinz.Models.DBSettings;

namespace Shoppinz.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<ShoppinzUser> _UserCollection;

        public AccountService(
            IOptions<ShoppinzDatabaseSettings> shoppinzDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                shoppinzDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                shoppinzDatabaseSettings.Value.DatabaseName);

            _UserCollection = mongoDatabase.GetCollection<ShoppinzUser>(
                shoppinzDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<ShoppinzUser>> GetAsync() =>
            await _UserCollection.Find(_ => true).ToListAsync();

        public async Task<ShoppinzUser?> GetAsync(string id) =>
            await _UserCollection.Find(x => x.SUserID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ShoppinzUser newBook) =>
            await _UserCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, ShoppinzUser updatedBook) =>
            await _UserCollection.ReplaceOneAsync(x => x.SUserID == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _UserCollection.DeleteOneAsync(x => x.SUserID == id);
    }
}
}
