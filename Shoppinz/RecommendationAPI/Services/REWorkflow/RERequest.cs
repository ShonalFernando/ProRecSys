namespace RecommendationAPI.Services.REWorkflow
{
    public class RERequest
    {
        public string Content { get; set; }

        public RERequest(string content)
        {
            Content = content;
        }
    }
}
