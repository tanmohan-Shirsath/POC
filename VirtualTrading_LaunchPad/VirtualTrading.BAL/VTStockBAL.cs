using AutoMapper;
using System;
using System.Collections.Generic;
using VirtualTrading.DAL;
using VirtualTrading.DAL.Models;
using VirtualTrading.Model;
using VirtualTrading.Common;

namespace VirtualTrading.BAL
{
    public class VTStockBAL
    {       
        VirtualTradeDataAccessLayer Context = new VirtualTradeDataAccessLayer();
        VirtualTrading.Common.VTCommonStockPrice vtcommonobj = new VirtualTrading.Common.VTCommonStockPrice();
        public List<StockpriceModel> GetAllStockPrice(DateTime dateParam, IMapper _mapper)
        {
            //List<StockpriceModel> stockPrices = Context.GetAllStockPrice(dateParam, _mapper);  

            List<StockpriceModel> stockPrices = vtcommonobj.GetAllStockPrice();

            return stockPrices;
        }
        public decimal GetStockPriceByStockSymbol(string StockSymbol, IMapper _mapper)
        {
            //decimal stockPrices = Context.GetStockPriceByStockSymbol(StockSymbol, _mapper);
            List<StockpriceModel> stockPrices = vtcommonobj.GetAllStockPrice();
            var result = stockPrices.Find(x => x.StockSymbol == StockSymbol);
            decimal stockPrice = Convert.ToDecimal(result.CloseMarket);
            return stockPrice;
        }

        public bool AddStockPrice(DateTime date, decimal openMarket, decimal highMarket, decimal lowMarket, decimal closeMarket, decimal volumeOfMarket, string stockSymbol, IMapper _mapper)
        {
            int paramStockId = Context.GetStockIdByStockSymbol(stockSymbol);
            bool result = Context.AddStockPrice(paramStockId, date, openMarket, highMarket, lowMarket, closeMarket, volumeOfMarket, _mapper);
            
            return result;
        }
    }
}