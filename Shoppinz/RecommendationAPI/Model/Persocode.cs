using MongoDB.Bson.Serialization.Attributes;

namespace RecommendationAPI.Model
{
    public class Persocode
    {
        [BsonId]
        public string _id { get; set; }

        public string  BlockedKeywords { get; set; }
        public string  BlockedProducts { get; set; }
        public string  Remarks { get; set; }
    }
}
