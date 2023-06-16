using RecommendationAPI.Model;

namespace RecommendationAPI.Services.REWorkflow
{
    public class ConcreteRE_Personalizer : iREHandler
    {
        private iREHandler _nextHandler;

        public TweetPost HandleRequest(RERequest request, TweetPost tpost)
        {
            if (request.Content == "PZ")
            {
                Console.WriteLine("Current Request");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine($"ConcreteHandlerC: Passing the request '{request.Content}' to the next handler.");
                _nextHandler.HandleRequest(request, tpost);
            }
            else
            {
                Console.WriteLine($"ConcreteHandlerC: End of the chain. Request '{request.Content}' cannot be handled.");
            }
        }

        public void SetNext(iREHandler handler)
        {
            _nextHandler = handler;
        }
    }
}
