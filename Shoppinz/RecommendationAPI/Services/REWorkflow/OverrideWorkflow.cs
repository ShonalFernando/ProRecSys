using Microsoft.AspNetCore.Components;
using RecommendationAPI.Model;
using RecommendationAPI.Services.REWorkflow.Engine;

namespace RecommendationAPI.Services.REWorkflow
{
    public class OverrideWorkflow
    {
        SentimentAnalyzer _SentimentAnalyzer = new SentimentAnalyzer();
        ProductRecommender _productRecommender = new ProductRecommender();
        Personalizer _Personalizer = new Personalizer();
        Mixer _Mixer = new Mixer();

        Product product = new Product();
        //Overriding the CoR Workflow for usability
        public Product RecommendationWF(string tweet, string persocode)
        {
            var pref = _Personalizer.GetPreferences(persocode);
            var rec = _productRecommender.GetProduct(tweet, pref);
            if (rec != null && rec.Item2)
            {
                var sentiment = _SentimentAnalyzer.GetSentiment(tweet, rec.Item1[0].ProductName);
                if(sentiment == "Positive")
                {
                    product = rec.Item1[0];
                }
                else
                {
                    product = _Mixer.GetProRec(rec);
                }

                return product;
            }
            else
            {
                return new Product();
            }
        }
    }
}
