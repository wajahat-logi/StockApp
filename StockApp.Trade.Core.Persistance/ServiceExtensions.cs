using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Trade.Core.Persistance.Context;
using StockApp.Trade.Core.Persistance.Repositories;

namespace StockApp.Trade.Core.Persistance
{
    public static class ServiceExtensions
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDBContext, ApplicationDBContext>();
            services.AddScoped<ITradeRepository, TradeRepository>();

        }
    }
}
