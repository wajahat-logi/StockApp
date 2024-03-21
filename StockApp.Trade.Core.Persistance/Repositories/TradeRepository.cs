using AutoMapper;
using Microsoft.Extensions.Logging;
using StockApp.Trade.Core.Persistance.Context;
using StockApp.Trade.Core.Request;

namespace StockApp.Trade.Core.Persistance.Repositories
{
    public class TradeRepository: ITradeRepository
    {
        private readonly IApplicationDBContext _db;
        private readonly ILogger<TradeRepository> _logger;
        private readonly IMapper _mapper;
        public TradeRepository(ILogger<TradeRepository> logger, IApplicationDBContext db, IMapper mapper) {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> AddTrade(TradeRequest request)
        {
            int successCode = 0;
            try {
                StockApp.Trade.Core.Entity.Trade trade = _mapper.Map<StockApp.Trade.Core.Entity.Trade>(request);
                _db.trade.Add(trade);
                successCode = await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Error in AddTrade: " + e);
            }
            return successCode;
        }
        public List<TradeRequest> GetAllTrades()
        {
            List<StockApp.Trade.Core.Entity.Trade> trade = _db.trade.ToList();
            List<TradeRequest> response = new List<TradeRequest>();
            trade.ForEach(x =>
            {
                TradeRequest mapped = _mapper.Map<TradeRequest>(x);
                response.Add(mapped);
            });
            return response;
        }

    }
}
