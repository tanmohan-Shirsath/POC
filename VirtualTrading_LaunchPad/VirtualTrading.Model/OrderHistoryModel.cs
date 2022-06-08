using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrading.Model
{
    public class OrderHistoryModel
    {
        public string StockSymbol { get; set; }
        public string StockCompanyName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Commision { get; set; }
        public decimal Total { get; set; }
        public decimal AccountValue { get; set; }
        public DateTime? DateTime { get; set; }
        public bool? TransactionType { get; set; }
        public bool? TradeStatus { get; set; }
    }
}
