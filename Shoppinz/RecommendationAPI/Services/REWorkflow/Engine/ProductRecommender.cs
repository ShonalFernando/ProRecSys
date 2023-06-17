using Microsoft.AspNetCore.Http;
using RecommendationAPI.Model;
using RecommendationAPI.Services.Database;
using System.Runtime.CompilerServices;

namespace RecommendationAPI.Services.REWorkflow.Engine
{
    public class ProductRecommender
    {
        private readonly ProductFetchStream _pfstream = null!;
        public Dictionary<string, int> MatchProducts { get; set; } = null!;

        public Product GetProduct(string OriginalText)
        {
            //Get Original Text and Remove Articales and Unneccessary words and Symbols

            //String is splitted into words
            string[] TweetedWords;

            //Split by space
            TweetedWords = OriginalText.Split(' ');

            //Get the Database list of products and keywords
            var products = _pfstream.GetProduct();

            //Run loop through Words
            foreach (var word in TweetedWords)
            {
                foreach (var productkw in products)
                {
                    if (word == productkw.Keywords0 ||
                        word == productkw.Keywords1 ||
                        word == productkw.Keywords2 ||
                        word == productkw.Keywords3 ||
                        word == productkw.Keywords4)
                    {
                        //Check if product is already added to the dictionary
                        if (MatchProducts.ContainsKey(productkw.ProductName))
                        {
                            MatchProducts[productkw.ProductName] += 1;
                        }
                        else
                        {
                            MatchProducts.Add(productkw.ProductName, 1);
                        }
                    }
                }
            }

            //Check what product has the most weight
            string _mpMax = "WAITING";
            try
            {
                _mpMax = MatchProducts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            }
            catch (Exception)
            {

                _mpMax = "NODATA";
            }

            //Now get that product
            var rProduct =  _pfstream.GetProduct("_mpMax");

            //If the product is null send a message
            if(rProduct == null)
            {
                rProduct = new Product() { ProductName= "NOPRODUCT"};
            }

            //Return the product
            return rProduct;
        }
    }
}
