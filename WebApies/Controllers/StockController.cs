using Microsoft.AspNetCore.Mvc;
using Persistence.Modal;
using WebApies.Modal;
using WebApies.Services;

namespace WebApies.Controllers
{
  

    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        
        private readonly ILogger<StockController> _logger;
        private readonly IStockService _service;
        public StockController(ILogger<StockController> logger, IStockService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("GetAllStocks")]
        public IActionResult GetAllStocks()
        {
            List<Stock> response = _service.GetAllStocks();
            return Ok(response);
        }
        [HttpGet("GetStock/{symbol}")]
        public IActionResult GetStock(string symbol)
        {
            List<Stock> response = _service.GetStock(symbol);
            return Ok(response);
        }

        [HttpPost("AddStock")]
        public async Task<IActionResult> AddStock(StockRequest stock)
        {
            int response = await _service.AddStock(stock);
            return Ok(response);
        }

        [HttpPut("EditStock")]
        public async Task<IActionResult> EditStock(StockRequest stock)
        {
            int response = await _service.EditStock(stock);
            return Ok(response);
        }
        [HttpDelete("DeleteStock")]
        public async Task<IActionResult> DeleteStock(string symbol)
        {
            int response = await _service.DeleteStock(symbol);
            return Ok(response);
        }
    }

}
