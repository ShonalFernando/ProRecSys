using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecommendationAPI.Model
{
    public class Product
    {

        public ObjectId _id { get; set; }

        public string ProductName { get; set; } = null!; //TV
        public string? keywords0 { get; set; } //lesiure
        public string? keywords1 { get; set; } 
        public string? keywords2 { get; set; } 
        public string? keywords3 { get; set; }
        public string? keywords4 { get; set; }
    }
}
