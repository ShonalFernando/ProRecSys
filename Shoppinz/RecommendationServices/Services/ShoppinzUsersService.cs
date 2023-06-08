using AuthAPI.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AuthAPI.Services
{
    public class ShoppinzUsersService
    {
        private readonly IMongoCollection<UserAccount> _UserAccountsCollection;

        public ShoppinzUsersService(IOptions<ShoppinzDatabaseSettings> shoppinzDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                shoppinzDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                shoppinzDatabaseSettings.Value.DatabaseName);

            _UserAccountsCollection = mongoDatabase.GetCollection<UserAccount>(
                shoppinzDatabaseSettings.Value.ShoppinzUsersCollectionName);
        }

        public async Task<List<UserAccount>> GetAsync() =>
            await _UserAccountsCollection.Find(_ => true).ToListAsync();

        public async Task<UserAccount?> GetAsync(string id) =>
            await _UserAccountsCollection.Find(x => x.Username == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserAccount newBook) =>
            await _UserAccountsCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, UserAccount updatedBook) =>
            await _UserAccountsCollection.ReplaceOneAsync(x => x._id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _UserAccountsCollection.DeleteOneAsync(x => x._id == id);
    }
}
