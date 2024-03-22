using IdentityServer4.Services;
using StockApp.Trade.Core.Entities;
using StockApp.Trade.Core.Entity;

namespace StockApp.Trade.Service
{
    public class UserAuthenticateService
    {
        private readonly UserService userService;
        private readonly TokenService tokenService;

        public UserAuthenticateService(UserService userService, TokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        public string Authenticate(UserCredentials userCredentials)
        {
            userService.ValidateCredentials(userCredentials);
            string securityToken = tokenService.GetToken();

            return securityToken;
        }
    }
}
