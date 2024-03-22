using StockApp.Trade.Core.Persistance;
using StockApp.Trade.Core.Application;
using StockApp.Trade.Service;
using StockApp.Trade.Core.Persistance.Repositories;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System.Text;
using StockApp.Trade.Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();




IConfigurationSection settingsSection = builder.Configuration.GetSection("AppSettings");
AppSettings settings = settingsSection.Get<AppSettings>();
string signingKey = settings.EncryptionKey; // Assuming EncryptionKey is a string in your AppSettings
byte[] signingKeyBytes = Encoding.UTF8.GetBytes(signingKey);
//builder.Services.AddAuthentication(signingKeyBytes); // above
//builder.Services.AddAuthentication("Bearer") // mine
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "your_issuer_here",
//            ValidAudience = "your_audience_here",
//            IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes) // Set the signing key
//        };
//    });


builder.Services.Configure<AppSettings>(settingsSection);
builder.Services.AddTransient<AuthenticationService>();
builder.Services.AddTransient<TokenService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
