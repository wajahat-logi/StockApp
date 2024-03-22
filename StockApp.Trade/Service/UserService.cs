using StockApp.Trade.Core.Entity;
using StockApp.Trade.Core.Persistance.Repositories;
using StockApp.Trade.Core.Request;
using static IdentityServer4.Models.IdentityResources;

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
        public void ValidateCredentials(UserCredentials userCredentials)
        {
            UserRequest user = _repo.GetAUser(userCredentials.Email);
            if (user != null)
            {
                if (userCredentials.Password != user.Password)
                {
                    throw new Exception();
                }
            }
        }
    }
}
