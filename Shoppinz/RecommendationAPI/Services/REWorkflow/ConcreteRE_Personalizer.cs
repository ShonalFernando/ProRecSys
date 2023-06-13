namespace RecommendationAPI.Services.REWorkflow
{
    public class ConcreteRE_Personalizer
    {
        private iREHandler _nextHandler;

        public void HandleRequest(RERequest request)
        {
            if (request.Content == "C")
            {
                Console.WriteLine("Current Request");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine($"ConcreteHandlerC: Passing the request '{request.Content}' to the next handler.");
                _nextHandler.HandleRequest(request);
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
