using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using VirtualTrading.Model;

namespace VirtualTrading.DAL.Models
{
   public class StockPriceProfile : Profile
    {
        public StockPriceProfile() => 
            this.CreateMap<StockPrice, StockpriceModel>();

    }
}
