using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace StockApp.Trade.Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //// Add Identity Server
            //services.AddIdentityServer()
            //    .AddInMemoryClients(Config.Clients)
            //    .AddInMemoryApiResources(Config.ApiResources)
            //    .AddInMemoryIdentityResources(Config.IdentityResources)
            //    .AddTestUsers(Config.Users)
            //    .AddDeveloperSigningCredential();

            // Add authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourIssuer",
                    ValidAudience = "yourAudience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKey"))
                };
            });
            //// Add authorization
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("RequireAdminRole", policy =>
            //        policy.RequireRole("Admin"));
            //});


        }

    }
}
