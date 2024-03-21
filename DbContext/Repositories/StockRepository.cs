using AutoMapper;
using Microsoft.Extensions.Logging;
using Persistence.Context;
using Persistence.Modal;
using WebApies.Modal;
using WebApies.Services;

namespace Persistence.Repositories
{
    public class StockRepository: IStockRepository
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<StockRepository> _logger;
        public StockRepository(ILogger<StockRepository> logger, IApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public List<Stock> GetAllStocks()
        {
            List<Stock> reposne = _db.stock.ToList();
            return reposne;
        }
        public List<Stock> GetStock(string symbol)
        {
            List<Stock> reposne = _db.stock.Where(x => x.Symbol == symbol).ToList();
            return reposne;
        }
        public async Task<int> AddStock(StockRequest request)
        {
            int succesCode = 0;
            try
            {
                Stock stock = _mapper.Map<Stock>(request);
                _db.stock.Add(stock);
                succesCode = await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Error in AddStock: " + e);
            }
            return succesCode;
        }

        public async Task<int> EditStock(StockRequest request)
        {
            int succesCode = 0;
            try
            {
                Stock stockFound = _db.stock.FirstOrDefault(x => x.Symbol == request.Symbol);
                if (stockFound == null)
                {
                    succesCode = 0;
                }
                else
                {
                    stockFound.UpdatedPrice = request.Price;
                    succesCode = await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EditStock: {e}");
            }
            return succesCode;
        }

        public async Task<int> DeleteStock(string symbol)
        {
            int succesCode = 0;
            try
            {
                Stock stockFound = _db.stock.FirstOrDefault(x => x.Symbol == symbol);
                if (stockFound != null)
                {
                    _db.stock.Remove(stockFound);
                    succesCode = await _db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in EditStock: {e}");
            }
            return succesCode;
        }
    }
}
