using AuthAPI.Model;
using AuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopinzController : ControllerBase
    {
        private readonly ShoppinzUsersService _ShoppinzService;

        public ShopinzController(ShoppinzUsersService shoppinzService)
        {
            _ShoppinzService = shoppinzService;
        }

        [HttpGet]
        public async Task<List<UserAccount>> Get() =>
        await _ShoppinzService.GetAsync();

        //Get UserDetails
        [HttpGet("{Username}")]
        public async Task<ActionResult<UserAccount>> Get(string Username)
        {
            var uacc = await _ShoppinzService.GetAsync(Username);

            if (uacc is null)
            {
                return Ok(new UserAccount() { Username = "NOUSER404", Password = "NOPASSWORD404" });
                //Override the return below
                //return NotFound();
            }
            //Append
            uacc.Password = EncryptionServices.EncryptPass(uacc.Password,2);

            return uacc;
        }

        //Account Creation
        [HttpPost]
        public async Task<IActionResult> Post(UserAccount newuser)
        {
            try
            {
                await _ShoppinzService.CreateAsync(newuser);

                return Created(nameof(Get), newuser);
            }
            catch (Exception e)
            {

                return BadRequest();
            }

        }
    }
}
