using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Request
{
    public class TradeRequest
    {
        public int StockId { get; set; } // Foreign key referencing Stock table
        public int UserId { get; set; } // Foreign key referencing User table
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
}
