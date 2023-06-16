using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecommendationAPI.Model;
using RecommendationAPI.Model.AppSettingModels;

namespace RecommendationAPI.Services.Database
{
    public class ProductFetchStream
    {
        private readonly IMongoCollection<Product> _ProductCollection;

        public ProductFetchStream(IOptions<ProductCluster> productcluster)
        {
            var mongoClient = new MongoClient(
                productcluster.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                productcluster.Value.DatabaseName);

            _ProductCollection = mongoDatabase.GetCollection<Product>(
                productcluster.Value.ShoppinzUsersCollectionName);
        }

        public async Task<List<Product>> GetAsync() =>
            await _ProductCollection.Find(_ => true).ToListAsync();

        public async Task<Product?> GetAsync(string productname) =>
            await _ProductCollection.Find(x => x.ProductName == productname).FirstOrDefaultAsync();

        public async Task CreateAsync(Product newBook) =>
            await _ProductCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string productname, Product updatedproduct) =>
            await _ProductCollection.ReplaceOneAsync(x => x.ProductName == productname, updatedproduct);

        public async Task RemoveAsync(string productname) =>
            await _ProductCollection.DeleteOneAsync(x => x.ProductName == productname);
    }
}
