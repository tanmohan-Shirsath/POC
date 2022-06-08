using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualTrading.API.Models
{
    public class BuySale
    {
        public int UserId { get; set; }
        public string StockSymbol { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public string StrTransactionType { get; set; }
        public DateTime datetime { get; set; }
    }
}
