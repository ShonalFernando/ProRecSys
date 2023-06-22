using Microsoft.AspNetCore.Http;
using RecommendationAPI.Model;
using RecommendationAPI.Services.Database;
using System.Runtime.CompilerServices;

namespace RecommendationAPI.Services.REWorkflow.Engine
{
    public class ProductRecommender
    {
        private readonly ProductFetchStream _pfstream = new ProductFetchStream();
        public Dictionary<string, int> MatchProducts { get; set; } = null!;

        public Tuple<List<Product>,bool> GetProduct(string TweetText, Persocode persocode)
        {
            //Get Original Text and Remove Articales and Unneccessary words and Symbols

            //String (Tweet Post) needs to be splitted into seperate words and store it in a list
            //We chould create a List of Strings(i.e., words)
            List<string> TweetedWords;

            //Create a Boolean Variable to denote whether the return list of products contains a AI recommended Product
            bool isContainsRecommendation = false;

            //Create a list of products to return
            //The list contains [0] - AI recommended Product [1], [2], ... - Prefered Product
            List<Product> ReturningProducts = new List<Product>();

            //Split by space
            TweetedWords = TweetText.Split(' ').ToList();

            //Get the Database list of products and keywords
            var _products = _pfstream.GetProduct();

            //A: Run loop through Words in the tweet
            foreach (var word in TweetedWords.ToList())
            {
                //B: Check whether the user has no blocked words
                if (persocode.BlockedKeywords != null)
                {
                    //C: If yes, Now we have to eliminate blocked Keywords taken from the user preferences
                    foreach (var BlockedWord in persocode.BlockedKeywords.ToList())
                    {
                        //Creating a list is easy to work with, i.e., collections
                        //D: Now check each word is matching
                        if( BlockedWord == word)
                        {
                            TweetedWords.Remove(word);
                        }
                    }
                }
                //Run Through Each Product in the Product List
                foreach (var productkw in _products.ToList())
                {
                    //Check if a word matches any of the product keywords
                    if (word == productkw.keywords0 ||
                        word == productkw.keywords1 ||
                        word == productkw.keywords2 ||
                        word == productkw.keywords3 ||
                        word == productkw.keywords4)
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


            string _mpMax = "";
            if (MatchProducts != null)
            {
                //We need to add the prefered products to the list
                //Before that we need to know the maximum weight of the matched products
                var MaxValue = MatchProducts.Values.Max(); // 

                //Check what product has the most weight
                _mpMax = MatchProducts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            }
            //Now get that product
            Product? rProduct = new Product();

            if (!string.IsNullOrEmpty(_mpMax))
            {
                //If the string is not null get the product
                rProduct = _pfstream.GetProduct(_mpMax);
            }

            if(rProduct != null)
            {
                //If the Product is not null add it
                ReturningProducts.Add(rProduct);
                isContainsRecommendation = true;
            }

            //Now the rest of the list is populated by user product preferences
            if (persocode.PreferedProducts != null)
            {
                foreach (var _preferedproduct in persocode.PreferedProducts.ToList())
                {
                    rProduct = _pfstream.GetProduct(_preferedproduct);
                    if (rProduct != null)
                    {
                        ReturningProducts.Add(rProduct); 
                    }
                } 
            }

            //Return the product list with #1 index containing AI (not ML) recommendation and rest is preferences
            return Tuple.Create(ReturningProducts, isContainsRecommendation);
        }
    }
}
