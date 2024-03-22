using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Request
{
    public class UserRequest
    {
        public string name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public IEnumerable<Claim> Claims()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };
            claims.AddRange(Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }
    }
}
