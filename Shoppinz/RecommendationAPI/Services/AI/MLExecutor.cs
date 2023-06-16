﻿using AuthAPI;

namespace RecommendationAPI.AI
{
    public class MLExecutor
    {
        public string GetSentiment(string tweet, string identifiedProduct)
        {
            //Load sample data
            var sampleData = new SAnalyzer.ModelInput()
            {
                Tweet_text = @tweet,
                Emotion_in_tweet_is_directed_at = @identifiedProduct,
            };

            //Load model and predict output
            var result = SAnalyzer.Predict(sampleData);

            return result.Prediction;
        }
    }
}
