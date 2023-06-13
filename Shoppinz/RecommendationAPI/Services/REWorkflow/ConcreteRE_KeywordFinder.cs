namespace RecommendationAPI.Services.REWorkflow
{
    public class ConcreteRE_KeywordFinder : iREHandler
    {
        private iREHandler _nextHandler;

        public void HandleRequest(RERequest request)
        {
            if(request.Content == "A")
            {
                Console.WriteLine("Current Request");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine($"ConcreteHandlerA: Passing the request '{request.Content}' to the next handler.");
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine($"ConcreteHandlerA: End of the chain. Request '{request.Content}' cannot be handled.");
            }
        }

        public void SetNext(iREHandler handler)
        {
            _nextHandler = handler;
        }
    }
}
