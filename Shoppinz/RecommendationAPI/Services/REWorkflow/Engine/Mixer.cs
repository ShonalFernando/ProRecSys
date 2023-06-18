using RecommendationAPI.Model;

namespace RecommendationAPI.Services.REWorkflow.Engine
{
    public class Mixer
    {
        public Product GetProRec(Tuple<List<Product>,bool> _productsrecommendations, string sentiment)
        {
            //The list of products: First product may contain the recommended product, The rest is preferences
            //sentiment is the string of emotion if a recommended product exist denoted by the bool

            //Check if a recommended product exist
            if(_productsrecommendations.Item2)
            {

            }
            return new Product();
        }
    }
}
