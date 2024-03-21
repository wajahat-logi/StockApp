using StockApp.Trade.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Entity
{
    public class Trade: BaseEntity
    {
        public int StockId { get; set; } // Foreign key referencing Stock table
        public int UserId { get; set; } // Foreign key referencing User table
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
