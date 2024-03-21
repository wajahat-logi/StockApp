
using Persistence.Modal;
using WebApies.Modal;

namespace WebApies.Services
{
    public interface IStockRepository
    {
        List<Stock> GetAllStocks();
        List<Stock> GetStock(string symbol);
        Task<int> AddStock(StockRequest request);
        Task<int> EditStock(StockRequest request);
        Task<int> DeleteStock(string symbol);
    }
}
