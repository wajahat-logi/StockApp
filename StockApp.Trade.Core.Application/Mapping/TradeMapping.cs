using AutoMapper;
using StockApp.Trade.Core.Entity;
using StockApp.Trade.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Trade.Core.Application.Mapping
{
    public class TradeMapping: Profile
    {
        public TradeMapping()
        {
            CreateMap<TradeRequest,StockApp.Trade.Core.Entity.Trade>().ForMember(des => des.Price, src => src.MapFrom(opt => opt.Amount));
            CreateMap<StockApp.Trade.Core.Entity.Trade, TradeRequest>().ForMember(des => des.Amount, src => src.MapFrom(opt => opt.Price));

            CreateMap<UserRequest, User>().ForMember(des => des.Username, src => src.MapFrom(opt => opt.name));
            CreateMap<User, UserRequest>().ForMember(des => des.name, src => src.MapFrom(opt => opt.Username));

        }
    }
}
