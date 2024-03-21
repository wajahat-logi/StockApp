using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Request
{
    public class UserRequest
    {
        public string name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
