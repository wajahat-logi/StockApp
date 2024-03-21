using StockApp.Trade.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Persistance.Repositories
{
    public interface IUserRepository
    {
        List<UserRequest> GetAllUsers();
        UserRequest GetAUser(string email);
        Task<int> AddUser(UserRequest request);
        Task<int> EditUser(UserRequest request);
        Task<int> DeleteUser(string email);
    }
}
