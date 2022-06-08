using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualTrading.DAL.Models;
using VirtualTrading.Model;

namespace VirtualTrading.Interface
{
    public interface IStockPriceRepository
    {
        public List<StockpriceModel> GetAllStockPrice(DateTime dateParam, IMapper _mapper);
        public decimal GetStockPriceByStockSymbol(string StockSymbol, IMapper _mapper);
        public bool AddStockPrice(DateTime date, decimal openMarket, decimal highMarket, decimal lowMarket, decimal closeMarket, decimal volumeOfMarket, string stockSymbol, IMapper _mapper);
    }
}
