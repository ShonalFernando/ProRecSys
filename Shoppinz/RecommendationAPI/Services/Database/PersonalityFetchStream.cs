using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecommendationAPI.Model.AppSettingModels;
using RecommendationAPI.Model;

namespace RecommendationAPI.Services.Database
{
    public class PersonalityFetchStream
    {
        private readonly IMongoCollection<Persocode> _persocodeCollection;

        public PersonalityFetchStream(IOptions<ProductCluster> productcluster)
        {
            var mongoClient = new MongoClient(
                productcluster.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                productcluster.Value.DatabaseName);

            _persocodeCollection = mongoDatabase.GetCollection<Persocode>(
                productcluster.Value.ShoppinzUsersCollectionName);
        }

        public async Task<List<Persocode>> GetAsync() =>
            await _persocodeCollection.Find(_ => true).ToListAsync();

        public async Task<Persocode?> GetAsync(string productname) =>
            await _persocodeCollection.Find(x => x._id == productname).FirstOrDefaultAsync();

        public async Task CreateAsync(Persocode newcode) =>
            await _persocodeCollection.InsertOneAsync(newcode);

        public async Task UpdateAsync(string id, Persocode updatedproduct) =>
            await _persocodeCollection.ReplaceOneAsync(x => x._id == id, updatedproduct);

        public async Task RemoveAsync(string id) => 
            await _persocodeCollection.DeleteOneAsync(x => x._id == id);
    }
}
