using StockApp.Trade.Core.Persistance.Repositories;
using StockApp.Trade.Core.Request;

namespace StockApp.Trade.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public List<UserRequest> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
        public UserRequest GetAUser(string email)
        {
            return _repo.GetAUser(email);
        }

        public async Task<int> AddUser(UserRequest request)
        {
            return await _repo.AddUser(request);
        }

        public async Task<int> EditUser(UserRequest request)
        {
            return await _repo.EditUser(request);
        }

        public async Task<int> DeleteUser(string email)
        {
            return await _repo.DeleteUser(email);
        }
    }
}
