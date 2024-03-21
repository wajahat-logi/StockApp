using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApies.Modal;

namespace Persistence.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Stock> stock { get; set; }
        Task<int> SaveChangesAsync();
    }
}
