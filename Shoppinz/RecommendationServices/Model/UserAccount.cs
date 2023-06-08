using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthAPI.Model
{
    public class UserAccount
    {
        [BsonId]
        public string? _id { get; set; }


        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string[] PersonalCard { get; set; } = null!; //First Name , NIC , DOB, Last Name and Other Personal Details

        public string PersonalCode { get; set; } = null!; //Application predefined code for Preferences
    }
}
