using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecommendationAPI.Model;
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

            owf.RecommendationWF("","")

            return Ok(aiez.GetSentiment("",""));
        }

    }
}
