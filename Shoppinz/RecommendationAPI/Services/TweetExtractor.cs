using TweetSharp;

namespace RecommendationAPI.Services
{
    public class TweetExtractor
    {
        public static string _consumerKey = "Bd0ls5u6VrxB1ptqjBs49WPBC"; // Your key
        public static string _consumerSecret = "yCjwK3k24e46kDeYPt1aluA3nkiSorzmgQ5iJVYw6htMBc69cB"; // Your key  
        public static string _accessToken = "1524361495513280512-x9fDEvpZXZnD5r9cB7bE7a4Ii9yhIX"; // Your key  
        public static string _accessTokenSecret = "MQDYvzw9dNnmWf49KGRncPXx61SvFButRwqjdeJObVy6G"; // Your key  

        public string twext (string Username)
        {
            TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
            twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);

            var options = new ListTweetsOnUserTimelineOptions()
            {
                ScreenName = Username,
                SinceId = 0,
                Count = 5
            };
            var currentTweets = twitterService.ListTweetsOnUserTimeline(options);

            int tweetcount = 1;

            string Tweets = "";
            //Resulttype can be TwitterSearchResultType.Popular or TwitterSearchResultType.Mixed or TwitterSearchResultType.Recent  
            List<TwitterStatus> resultList = new List<TwitterStatus>(currentTweets);
            foreach (var tweet in currentTweets)
            {
                try
                {
                    //tweet.User.ScreenName;  
                    //tweet.User.Name;   
                    //tweet.Text; // Tweet text  
                    //tweet.RetweetCount; //No of retweet on twitter  
                    //tweet.User.FavouritesCount; //No of Fav mark on twitter  
                    //tweet.User.ProfileImageUrl; //Profile Image of Tweet  
                    //tweet.CreatedDate; //For Tweet posted time  
                    //"https://twitter.com/intent/retweet?tweet_id=" + tweet.Id;  //For Retweet  
                    //"https://twitter.com/intent/tweet?in_reply_to=" + tweet.Id; //For Reply  
                    //"https://twitter.com/intent/favorite?tweet_id=" + tweet.Id; //For Favorite  

                    //Above are the things we can also get using TweetSharp.  

                    Tweets += tweet.Text;
                     tweetcount++;
                }
                catch { }
            }
            return Tweets;
        }
    }
}
