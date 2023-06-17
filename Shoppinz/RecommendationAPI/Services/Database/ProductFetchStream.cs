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

        public List<Product> GetProduct() =>
             _ProductCollection.Find(_ => true).ToList();

        public Product? GetProduct(string productname) =>
             _ProductCollection.Find(x => x.ProductName == productname).FirstOrDefault();

        public void Create(Product newBook) =>
             _ProductCollection.InsertOne(newBook);

        public void UpdateAsync(string productname, Product updatedproduct) =>
             _ProductCollection.ReplaceOne(x => x.ProductName == productname, updatedproduct);

        public void RemoveAsync(string productname) =>
             _ProductCollection.DeleteOne(x => x.ProductName == productname);
    }
}
