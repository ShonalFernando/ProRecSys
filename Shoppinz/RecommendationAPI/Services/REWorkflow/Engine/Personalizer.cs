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
        public Persocode GetPreferences(string persocode)
        {
            var Perso =  _pfstream.GetPerso(persocode);
            if (Perso != null)
            {
                //Return the Personal Preferences
                return Perso;

            }
            else
            {
                return new Persocode();
            }
        }
    }
}
