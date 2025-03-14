﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shoppinz.Models
{
    public class ShoppinzUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string?   SUserID { get; set; }                           //Autogenerated User ID

        [BsonElement("Name")]
        public string    UserName { get; set; }         = null!;         //
        public string    UserPassword { get; set; }     = null!;         //
        public string    UEmail { get; set; }        = null!;            //
        public string[]? UserCard { get; set; }                          //String Contains First Name, Last Name and other personal Information
        public string?   ProductRecommendation { get; set; }             //
        public string?   ProductRecommendationAlternate { get; set; }    //
        public string?   PersonalizedCode { get; set; }                  //
    }
}
