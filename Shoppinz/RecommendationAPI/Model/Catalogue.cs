namespace RecommendationAPI.Model
{
    public class Catalogue
    {
        //Recommended Product
        public string _id { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductRemarks { get; set; }
    }
}
