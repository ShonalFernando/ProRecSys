using RecommendationAPI.Services.REWorkflow;

namespace RecommendationAPI.Services
{
    public class RecommendationFlow
    {
        public void RecommendProduct(string rawtweet) 
        {
            //Handler Instances
            var REHND1 = new ConcreteRE_KeywordFilter();
            var REHND2 = new ConcreteRE_Personalizer();
            var REHND3 = new ConcreteRE_SentimentAnalysis();

            //Chain
            REHND1.SetNext(REHND2); //KeywordFinder >>> Personalizer
            REHND2.SetNext(REHND3); //Personalizer  >>> Analyzer

            //Create Request
            var FindKeywords = new RERequest("KWF");
            var Personalize = new RERequest("PZ");
            var Analyze = new RERequest("SA");

            //Request Handling
            

        }
    }
}
