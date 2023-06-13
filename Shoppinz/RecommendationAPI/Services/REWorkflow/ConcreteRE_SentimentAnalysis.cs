namespace RecommendationAPI.Services.REWorkflow
{
    public class ConcreteRE_SentimentAnalysis
    {
        private iREHandler _nextHandler;

        public void HandleRequest(RERequest request)
        {
            if (request.Content == "B")
            {
                Console.WriteLine("Current Request B");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine($"ConcreteHandlerB: Passing the request '{request.Content}' to the next handler.");
                _nextHandler.HandleRequest(request);
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

