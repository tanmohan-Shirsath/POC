using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrading.Model
{
    public class StockpriceModel
    {
        public string StockSymbol { get; set; }
        public string StockCompanyName { get; set; }
        public DateTime Date { get; set; }
        public decimal? OpenMarket { get; set; }
        public decimal? HighMarket { get; set; }
        public decimal? LowMarket { get; set; }
        public decimal? CloseMarket { get; set; }
        public decimal? VolumeOfMarket { get; set; }
    }
}
