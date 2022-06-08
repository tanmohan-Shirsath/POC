using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace VirtualTrading.DAL.Models
{

    [Table("StockPrice")]
    public partial class StockPrice
    {
        [Key]
        public int Id { get; set; }
        [Column("stockID")]
        public int StockId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("openMarket", TypeName = "decimal(18, 2)")]
        public decimal? OpenMarket { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? HighMarket { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? LowMarket { get; set; }
        [Column("closeMarket", TypeName = "decimal(18, 2)")]
        public decimal? CloseMarket { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? VolumeOfMarket { get; set; }

        [ForeignKey(nameof(StockId))]
        [InverseProperty("StockPrices")]
        public virtual Stock Stock { get; set; }
    }
}
