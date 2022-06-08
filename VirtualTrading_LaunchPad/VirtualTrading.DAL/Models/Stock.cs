using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace VirtualTrading.DAL.Models
{
    [Table("Stock")]
    public partial class Stock
    {
        public Stock()
        {
            StockPrices = new HashSet<StockPrice>();
            TradeHistories = new HashSet<TradeHistory>();
        }

        [Key]
        [Column("StockID")]
        public int StockId { get; set; }
        [Required]
        [Column("symbol")]
        [StringLength(10)]
        public string Symbol { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [InverseProperty(nameof(StockPrice.Stock))]
        public virtual ICollection<StockPrice> StockPrices { get; set; }
        [InverseProperty(nameof(TradeHistory.Stock))]
        public virtual ICollection<TradeHistory> TradeHistories { get; set; }
    }
}
