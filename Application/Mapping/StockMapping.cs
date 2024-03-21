using AutoMapper;
using Persistence.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApies.Modal;

namespace Application.Mapping
{
    public class StockMapping: Profile
    {
        public StockMapping()
        {
            CreateMap<StockRequest, Stock>().ForMember( des => des.UpdatedPrice, source => source.MapFrom(x => x.Price));
        }
    }
}
