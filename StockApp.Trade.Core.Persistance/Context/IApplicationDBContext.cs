using Microsoft.EntityFrameworkCore;
using StockApp.Trade.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Persistance.Context
{
    public interface IApplicationDBContext
    {
        DbSet<User> user { get; set; }
        DbSet<StockApp.Trade.Core.Entity.Trade> trade { get; set; }
        Task<int> SaveChangesAsync();
    }
}
