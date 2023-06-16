using RecommendationAPI.Model;
using RecommendationAPI.Services.Database;

namespace RecommendationAPI.Services.REWorkflow.Engine
{
    public class Personalizer
    {
        private readonly PersonalityFetchStream _pfstream = null!;
        //Blocked Products
        //Blocked Keywords

        //Get the Personal preferences of the user
        public async Task<Product> GetPreferences(string persocode)
        {
            var Perso = await _pfstream.GetAsync(persocode);
            if(Perso!=null)
            {
                //Get Product Name from preffered
                string[]? _productpreffered = Perso.PreferedProducts;

                //Get Blocked Keywords
                string[]? _blockedkeywords = Perso.BlockedKeywords;

                return new Product();
            }
            else
            {
                return new Product();
            }
        }
    }
}
