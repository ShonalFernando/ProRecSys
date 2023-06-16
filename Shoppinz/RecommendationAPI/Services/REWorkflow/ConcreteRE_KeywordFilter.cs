using RecommendationAPI.Model;
using RecommendationAPI.ServiceEnums;

namespace RecommendationAPI.Services.REWorkflow
{
    public class ConcreteRE_KeywordFilter : iREHandler
    {
        private iREHandler? _nextHandler;

        public TweetPost HandleRequest(RERequest request, TweetPost tpost)
        {
            if(request.Content == "KWF")
            {

                
                return tpost;
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request, tpost);
                return tpost;
            }
            else
            {
                Console.WriteLine($"ConcreteHandlerA: End of the chain. Request '{request.Content}' cannot be handled.");
                return tpost;
            }
        }

        public void SetNext(iREHandler handler)
        {
            _nextHandler = handler;
        }
    }
}