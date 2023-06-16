namespace RecommendationAPI.Model.ModelInterfaces
{
    public interface iPost
    {
        string PostID { get; set; }
        string Username { get; set; }
        string Tweet { get; set; }
        string Emotion { get; set; }
        string[] Keywords { get; set; }
        string TargetProduct { get; set; }

        bool isKeywordsExtracted { get; set; }
        bool isPostFiltered { get; set; }
        bool isSentimentAnalyzed { get; set; }
    }
}
