using RecommendationAPI.Model;

namespace RecommendationAPI.Services.REWorkflow
{
    public class ConcreteRE_SentimentAnalysis : iREHandler
    {
        private iREHandler _nextHandler;

        public void HandleRequest(RERequest request, TweetPost tpost)
        {
            if (request.Content == "SA")
            {
                Console.WriteLine("Current Request B");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine($"ConcreteHandlerB: Passing the request '{request.Content}' to the next handler.");
                _nextHandler.HandleRequest(request, tpost);
            }
            else
            {
                Console.WriteLine($"ConcreteHandlerB: End of the chain. Request '{request.Content}' cannot be handled.");
            }
        }

        public void SetNext(iREHandler handler)
        {
            _nextHandler = handler;
        }
    }
}

