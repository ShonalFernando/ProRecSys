using AuthAPI;

namespace RecommendationAPI.AI
{
    public class AIExecutor
    {
        public string GetSentiment()
        {
            //Load sample data
            var sampleData = new SAnalyzer.ModelInput()
            {
                Tweet_text = @".@wesley83 I have a 3G iPhone. After 3 hrs tweeting at #RISE_Austin, it was dead!  I need to upgrade. Plugin stations at #SXSW.",
                Emotion_in_tweet_is_directed_at = @"iPhone",
            };

            //Load model and predict output
            var result = SAnalyzer.Predict(sampleData);

            return result.Prediction;
        }
    }
}
