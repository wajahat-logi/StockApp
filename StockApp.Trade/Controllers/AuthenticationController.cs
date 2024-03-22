using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StockApp.Trade.Core.Entity;
using StockApp.Trade.Service;
using System.Security.Authentication;

namespace StockApp.Trade.Controllers
{
    public class AuthenticationController: Controller
    {
        private readonly UserAuthenticateService _auth;
        public AuthenticationController(UserAuthenticateService auth) {
            _auth = auth;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials userCredentials)
        {
            try
            {
                string token = _auth.Authenticate(userCredentials);
                return Ok(token);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
