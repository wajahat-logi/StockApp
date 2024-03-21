using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Persistence.Context;
using Persistence.Modal;
using System.Linq;
using WebApies.Modal;

namespace WebApies.Services
{
    public class StockService: IStockService
    {
        private readonly IStockRepository _repo;
        private readonly ILogger<StockService> _logger;
        public StockService(ILogger<StockService> logger, IStockRepository repo) {
            _repo = repo;
        }

        public List<Stock> GetAllStocks()
        {
            return _repo.GetAllStocks();
        }
        public List<Stock> GetStock(string symbol)
        {
            return _repo.GetStock(symbol);
        }
        public async Task<int> AddStock(StockRequest request)
        {
            return await _repo.AddStock(request) ;
        }

        public async Task<int> EditStock(StockRequest request)
        {
            return await _repo.EditStock(request);
        }

        public async Task<int> DeleteStock(string symbol)
        {
            return await _repo.DeleteStock(symbol);
        }
    }
}
