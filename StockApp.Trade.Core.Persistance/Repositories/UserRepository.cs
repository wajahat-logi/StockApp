using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Core;
using Microsoft.Extensions.Logging;
using StockApp.Trade.Core.Entity;
using StockApp.Trade.Core.Persistance.Context;
using StockApp.Trade.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Persistance.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IApplicationDBContext db, IMapper mapper, ILogger<UserRepository> logger) {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public List<UserRequest> GetAllUsers()
        {
            List< User> user = _db.user.ToList();
            List< UserRequest> result = new List<UserRequest>();
            user.ForEach(x =>
            {
                UserRequest u = _mapper.Map<UserRequest>(x);
                result.Add(u);
            });
            return result;
        }

        public UserRequest GetAUser(string email)
        {
            List< User> user = _db.user.Where( x=> x.Email == email).ToList<User>();
            UserRequest result = new UserRequest();
            if (user.Count > 0)
            {
                result = _mapper.Map<UserRequest>(user[0]);
            }
            return result;
        }

        public async Task<int> AddUser(UserRequest request)
        {
            int succesCode = 0;
            try
            {
                User user = _mapper.Map<User>(request);
                _db.user.Add(user);
                succesCode = await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Error in AddUser: " + e);
            }
            return succesCode;
        }

        public async Task<int> EditUser(UserRequest request)
        {
            int succesCode = 0;
            try
            {
                User userFound = _db.user.FirstOrDefault(x => x.Email == request.Email);
                if (userFound == null)
                {
                    succesCode = 0;
                }
                else
                {
                    _mapper.Map(request, userFound);
                    _db.user.Update(userFound);
                    succesCode = await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EditUser: {e}");
            }
            return succesCode;
        }

        public async Task<int> DeleteUser(string Email)
        {
            int succesCode = 0;
            try
            {
                User stockFound = _db.user.FirstOrDefault(x => x.Email == Email);
                if (stockFound != null)
                {
                    _db.user.Remove(stockFound);
                    succesCode = await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in DeleteUser: {e}");
            }
            return succesCode;
        }


    }
}
