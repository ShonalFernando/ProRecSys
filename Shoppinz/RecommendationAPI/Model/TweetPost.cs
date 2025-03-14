﻿using RecommendationAPI.Model.ModelInterfaces;

namespace RecommendationAPI.Model
{
    public class TweetPost : iPost
    {
        public string PostID { get; set ; }

        public string Username { get ; set ; }
        public string Emotion { get ; set ; }
        public string[] Keywords { get ; set; }

        public bool isPostFiltered { get ; set ; }
        public bool isSentimentAnalyzed { get ; set ; }
        public bool isKeywordsExtracted { get ; set; }
        public string TargetProduct { get; set; }
        public string Tweet { get ; set; }

        public TweetPost(string postID, string username,string tweet, string emotion, bool isPostFiltered, bool isSentimentAnalyzed, string[] keywords, bool isKeywordsExtracted)
        {
            PostID = postID;
            Username = username;
            Emotion = emotion;
            Keywords = keywords;
            Tweet = tweet;  

            this.isPostFiltered = isPostFiltered;
            this.isSentimentAnalyzed = isSentimentAnalyzed;
            this.isKeywordsExtracted = isKeywordsExtracted;
        }
    }
}
