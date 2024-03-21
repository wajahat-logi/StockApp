using StockApp.Trade.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Persistance.Repositories
{
    public interface ITradeRepository
    {
        Task<int> AddTrade(TradeRequest request);
        List<TradeRequest> GetAllTrades();
    }
}
