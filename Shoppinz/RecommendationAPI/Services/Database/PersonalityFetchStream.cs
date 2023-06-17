using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecommendationAPI.Model.AppSettingModels;
using RecommendationAPI.Model;

namespace RecommendationAPI.Services.Database
{
    public class PersonalityFetchStream
    {
        private readonly IMongoCollection<Persocode> _persocodeCollection;

        public PersonalityFetchStream(IOptions<PersocodeCluster> persocodecluster)
        {
            var mongoClient = new MongoClient(
                persocodecluster.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                persocodecluster.Value.DatabaseName);

            _persocodeCollection = mongoDatabase.GetCollection<Persocode>(
                persocodecluster.Value.ShoppinzpersoCollectionName);
        }

        public  List<Persocode> GetPerso() =>
             _persocodeCollection.Find(_ => true).ToList();

        public  Persocode? GetPerso(string id) =>
             _persocodeCollection.Find(x => x._id == id).FirstOrDefault();

        public  void Create(Persocode newcode) =>
             _persocodeCollection.InsertOne(newcode);

        public void Update(string id, Persocode updatedproduct) =>
             _persocodeCollection.ReplaceOne(x => x._id == id, updatedproduct);

        public void Remove(string id) => 
             _persocodeCollection.DeleteOne(x => x._id == id);
    }
}
