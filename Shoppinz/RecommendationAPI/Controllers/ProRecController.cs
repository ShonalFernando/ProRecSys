using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecommendationAPI.Model;
using RecommendationAPI.Services;
using RecommendationAPI.Services.Database;
using RecommendationAPI.Services.REWorkflow;
using RecommendationAPI.Services.REWorkflow.Engine;

namespace RecommendationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProRecController : ControllerBase
    {
        OverrideWorkflow owf = new OverrideWorkflow();
        //Get UserDetails
        [HttpGet("{Username}")]
        public async Task<ActionResult<Catalogue>> Get(string Username)
        {
            //SentimentAnalyzer aiez = new SentimentAnalyzer();
            //Catalogue cat = new Catalogue() { ProductName = "Test", ProductRemarks = "Good" };

            UserService userservice = new UserService();
            TweetExtractor twext = new TweetExtractor();

            var _profile = userservice.GetAsync(Username);
            string _uname = "";
            string CTweets = "";
            string pcode = "";
            if (_profile != null )
            {
                pcode = _profile.PersonalCode;
                _uname = _profile.Username;
                CTweets =  twext.twext(_uname);
            }
            return Ok(owf.RecommendationWF(CTweets, pcode));
        }

    }
}
