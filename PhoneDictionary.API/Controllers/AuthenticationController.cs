using Microsoft.AspNetCore.Mvc;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuth _auth;

        public AuthenticationController(IAuth auth)
        {
            _auth = auth;
        }
        
        [HttpGet]
        public ActionResult<string> Get(string login, string password)
        {
            var token = _auth.GetToken(login, password);
            if (token is null)
            {
                return NotFound();
            }

            return Ok(token);
        }
    }
}