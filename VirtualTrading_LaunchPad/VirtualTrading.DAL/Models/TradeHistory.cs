using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace VirtualTrading.DAL.Models
{
    [Table("TradeHistory")]
    public partial class TradeHistory
    {
        [Key]
        public int TransactionId { get; set; }
        public long TradeId { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Column("stockId")]
        public int StockId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Quantity { get; set; }
        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Commision { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AccountValue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTime { get; set; }
        public bool? TransactionType { get; set; }
        public bool? TradeStatus { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RemainingQuantity { get; set; }

        [ForeignKey(nameof(StockId))]
        [InverseProperty("TradeHistories")]
        public virtual Stock Stock { get; set; }
    }
}
