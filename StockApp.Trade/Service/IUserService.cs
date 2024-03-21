using Microsoft.AspNetCore.Mvc;
using StockApp.Trade.Core.Request;

namespace StockApp.Trade.Service
{
    public interface IUserService
    {
        List<UserRequest> GetAllUsers();
        UserRequest GetAUser(string email);
        Task<int> AddUser(UserRequest request);
        Task<int> EditUser(UserRequest user);
        Task<int> DeleteUser(string email);
    }
}
