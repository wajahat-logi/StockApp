using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApp.Trade.Core.Persistance.Repositories;
using StockApp.Trade.Core.Request;
using StockApp.Trade.Service;

namespace StockApp.Trade.Controllers
{
    //[Authorize]
    //[ApiController]

    public class StockTradeController: Controller
    {
        private readonly ITradeRepository _repo;
        private readonly IUserService _userRepo;
        public StockTradeController(ITradeRepository repo, IUserService userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }

        [HttpGet("GetAllTrades")]
        public IActionResult GetAllTrades()
        {
            List<TradeRequest> response = _repo.GetAllTrades();
            return Ok(response);
        }

        [HttpPost("AddTrade")]
        public async Task<IActionResult> AddTrade(TradeRequest request)
        {
            int successCode = await _repo.AddTrade(request);
            return Ok(successCode);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            List< UserRequest> users =  _userRepo.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("GetAUser/{email}")]
        public IActionResult GetAUser(string email)
        {
            UserRequest user = _userRepo.GetAUser(email);
            return Ok(user);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddStock(UserRequest user)
        {
            int response = await _userRepo.AddUser(user);
            return Ok(response);
        }

        [HttpPut("EditUser")]
        public async Task<IActionResult> EditStock(UserRequest user)
        {
            int response = await _userRepo.EditUser(user);
            return Ok(response);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            int response = await _userRepo.DeleteUser(email);
            return Ok(response);
        }


    }
}
