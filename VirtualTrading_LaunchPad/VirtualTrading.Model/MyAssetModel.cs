using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrading.Model
{
    public class MyAssetModel
    {
        public string StockSymbol { get; set; }
        public string StockCompanyName { get; set; }       
        public decimal RemainingQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Commision { get; set; }
        public decimal Total { get; set; }
        public decimal AccountValue { get; set; }
        public DateTime? DateTime { get; set; }

        public decimal profitloss { get; set; }
        public int StockId { get; set; }
        public string UserId { get; set; }
    }
}
