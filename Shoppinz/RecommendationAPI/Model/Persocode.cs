using MongoDB.Bson.Serialization.Attributes;

namespace RecommendationAPI.Model
{
    public class Persocode
    {
        [BsonId]
        public string _id { get; set; } = null!;
        public string PCode { get; set; } = null!;

        public string[]?  BlockedKeywords { get; set; }
        public string[]? PreferedProducts { get; set; }
        public string?  Remarks { get; set; }
    }
}
