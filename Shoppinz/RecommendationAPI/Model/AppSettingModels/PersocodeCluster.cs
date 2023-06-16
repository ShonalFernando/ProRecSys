namespace RecommendationAPI.Model.AppSettingModels
{
    public class PersocodeCluster
    {
        //WARNING!!! HARDCODED THE CONFIGURATION STRINGS, THIS IS A BAD PRACTISE THEREFORE REFACTOR LATER
        public string ConnectionString { get; set; } = "mongodb://localhost:27017"; //null!; 

        public string DatabaseName { get; set; } = "Shoppinz"; //null!;

        public string ShoppinzpersoCollectionName { get; set; } = "Persocode"; //null!;
    }
}
