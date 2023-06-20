using Microsoft.AspNetCore.Components;
using RecommendationAPI.Model;
using RecommendationAPI.Model.AppSettingModels;
using RecommendationAPI.Services.Database;
using RecommendationAPI.Services.REWorkflow.Engine;

namespace RecommendationAPI.Services.REWorkflow
{
    public class OverrideWorkflow
    {
        ProductFetchStream pfs = new ProductFetchStream();
        SentimentAnalyzer _SentimentAnalyzer = new SentimentAnalyzer();
        ProductRecommender _productRecommender = new ProductRecommender();
        Personalizer _Personalizer = new Personalizer();
        PersocodeCluster pfss = new PersocodeCluster();
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
                var plist = pfs.GetProduct();
                Random random = new Random();

                return plist[random.Next(0, plist.Count)];
            }
        }
    }
}
