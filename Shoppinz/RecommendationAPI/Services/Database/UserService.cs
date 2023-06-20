using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecommendationAPI.Model;

namespace RecommendationAPI.Services.Database
{
    public class UserService
    {
        private readonly IMongoCollection<UserAccount> _UserAccountsCollection;
        public string ConnectionString { get; set; } = "mongodb://localhost:27017"; //null!; 

        public string DatabaseName { get; set; } = "Shoppinz"; //null!;

        public string ShoppinzUsersCollectionName { get; set; } = "ShoppinzUsers"; //null!;


        public UserService(/*IOptions<ShoppinzDatabaseSettings> shoppinzDatabaseSettings*/)
        {
            var mongoClient = new MongoClient(
                /*shoppinzDatabaseSettings.Value.*/ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                /*shoppinzDatabaseSettings.Value.*/DatabaseName);

            _UserAccountsCollection = mongoDatabase.GetCollection<UserAccount>(
               /* shoppinzDatabaseSettings.Value.*/ShoppinzUsersCollectionName);
        }

        public  List<UserAccount> GetAsync() =>
             _UserAccountsCollection.Find(_ => true).ToList();

        public  UserAccount? GetAsync(string id) =>
             _UserAccountsCollection.Find(x => x.Username == id).FirstOrDefault();

        public void  CreateAsync(UserAccount newacc) =>
             _UserAccountsCollection.InsertOneAsync(newacc);

        public void UpdateAsync(string id, UserAccount updatedacc) =>
             _UserAccountsCollection.ReplaceOneAsync(x => x._id == id, updatedacc);

        public void RemoveAsync(string id) =>
             _UserAccountsCollection.DeleteOneAsync(x => x._id == id);
    }
}

