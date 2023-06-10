using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecommendationAPI.AI;
using RecommendationAPI.Model;

namespace RecommendationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProRecController : ControllerBase
    {
        //Get UserDetails
        [HttpGet("{Username}")]
        public async Task<ActionResult<Catalogue>> Get(string Username)
        {
            AIExecutor aiez = new AIExecutor();

            return Ok(aiez.GetSentiment());
        }

    }
}
