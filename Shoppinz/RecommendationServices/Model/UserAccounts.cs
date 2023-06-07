using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecommendationServices.Model
{
    public class UserAccounts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }


        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string[] PersonalCard { get; set; } = null!; //First Name , NIC , DOB, Last Name and Other Personal Details

        public string PersonalCode { get; set; } = null!; //Application predefined code for Preferences
    }
}
