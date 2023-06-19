using RecommendationAPI.Model;

namespace RecommendationAPI.Services.REWorkflow.Engine
{
    public class Mixer
    {
        public Product GetProRec(Tuple<List<Product>,bool> _productsrecommendations)
        {
            List<Product> _products = new List<Product>();
            Product _product = new Product();
            //The list of products: First product may contain the recommended product, The rest is preferences
            //sentiment is the string of emotion if a recommended product exist denoted by the bool

            _products = _productsrecommendations.Item1;

            //Check if a recommended product exist
            if (_productsrecommendations.Item2)
            {
                //Set the Product by query
                _product = _products.First();
            }
            else
            {
                Random random = new Random();
                _product = _products[random.Next(0, _products.Count)];
            }
            return _product;
        }
    }
}
