using System;
using System.Collections.Generic;
using VirtualTrading.Model;
using VirtualTrading.Interface;
using AutoMapper;

namespace VirtualTrading.API.Repository
{
    public class StockPriceRepository : IStockPriceRepository
    { 
        VirtualTrading.BAL.VTStockBAL _bal = new BAL.VTStockBAL();
        public List<StockpriceModel> GetAllStockPrice(DateTime dateParam, IMapper _mapper)
        {
            List<StockpriceModel> StockPrice = _bal.GetAllStockPrice(dateParam, _mapper);

            return StockPrice;
        }

        public decimal GetStockPriceByStockSymbol(string StockSymbol, IMapper _mapper)
        {
            decimal StockPrice = _bal.GetStockPriceByStockSymbol(StockSymbol, _mapper);

            return StockPrice;
        }

        public bool AddStockPrice(DateTime date, decimal openMarket, decimal highMarket, decimal lowMarket, decimal closeMarket, decimal volumeOfMarket, string stockSymbol, IMapper _mapper)
        {
            bool result = _bal.AddStockPrice(date, openMarket, highMarket, lowMarket, closeMarket, volumeOfMarket, stockSymbol, _mapper);

            return result;
        }
    }
}
