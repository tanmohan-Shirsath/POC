using AutoMapper;
using System;
using System.Collections.Generic;
using VirtualTrading.DAL;
using VirtualTrading.Model;
using VirtualTrading.Common;

namespace VirtualTrading.BAL
{
    public class VTMyAsset
    {
        VirtualTradeDataAccessLayer Context = new VirtualTradeDataAccessLayer();
        VirtualTrading.Common.VTCommonStockPrice vtcommonobj = new VirtualTrading.Common.VTCommonStockPrice();
        public List<MyAssetModel> GetMyAssetByUserID(string UserId, IMapper _mapper)
        {
            List<MyAssetModel> MyAssets = Context.GetMyAssetByUserID(UserId, _mapper);
            string StockSymbol;
            foreach (var myAsset in MyAssets)
            {
                StockSymbol = Context.GetStockSymbolByStockId(myAsset.StockId);
                myAsset.profitloss = calculateProfitloss(myAsset.UserId, StockSymbol, myAsset.StockId, myAsset.RemainingQuantity, myAsset.Total);
               
            }

            return MyAssets;
        }

        public decimal GetUserBalanceByUserID(string UserId)
        { 

            decimal UserBalance = Context.GetUserBalanceByUserID(UserId);
            return UserBalance;

        }

        public decimal GetStockPriceByStockSymbol(string StockSymbol)
        {
            //decimal stockPrices = Context.GetStockPriceByStockSymbol(StockSymbol, _mapper);
            List<StockpriceModel> stockPrices = vtcommonobj.GetAllStockPrice();
            var result = stockPrices.Find(x => x.StockSymbol == StockSymbol.Trim());
            decimal stockPrice = Convert.ToDecimal(result.CloseMarket);
            return stockPrice;
        }

        private decimal calculateProfitloss(string userId, string StockSymbol,int StockId, decimal quantity, decimal Total)
        {
            decimal CurrentPrice = GetStockPriceByStockSymbol(StockSymbol);

            decimal profitloss = (CurrentPrice * quantity) - Total;

            return profitloss;

        }

 
    }
}
