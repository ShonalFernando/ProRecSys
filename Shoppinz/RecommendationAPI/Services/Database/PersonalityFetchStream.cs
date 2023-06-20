using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RecommendationAPI.Model.AppSettingModels;
using RecommendationAPI.Model;

namespace RecommendationAPI.Services.Database
{
    public class PersonalityFetchStream
    {
        private readonly IMongoCollection<Persocode> _persocodeCollection;
        public string ConnectionString { get; set; } = "mongodb://localhost:27017"; //null!; 

        public string DatabaseName { get; set; } = "Shoppinz"; //null!;

        public string ShoppinzpersoCollectionName { get; set; } = "Persocode"; //null!;


        public PersonalityFetchStream(/*IOptions<PersocodeCluster> persocodecluster*/)
        {
            var mongoClient = new MongoClient(
                /*persocodecluster.Value.*/ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                /*persocodecluster.Value.*/DatabaseName);

            _persocodeCollection = mongoDatabase.GetCollection<Persocode>(
                /*persocodecluster.Value.*/ShoppinzpersoCollectionName);
        }

        public  List<Persocode> GetPerso() =>
             _persocodeCollection.Find(_ => true).ToList();

        public  Persocode? GetPerso(string Pcode) =>
             _persocodeCollection.Find(x => x.PCode == Pcode).FirstOrDefault();

        public  void Create(Persocode newcode) =>
             _persocodeCollection.InsertOne(newcode);

        public void Update(string Pcode, Persocode updatedproduct) =>
             _persocodeCollection.ReplaceOne(x => x.PCode == Pcode, updatedproduct);

        public void Remove(string Pcode) => 
             _persocodeCollection.DeleteOne(x => x.PCode == Pcode);
    }
}
