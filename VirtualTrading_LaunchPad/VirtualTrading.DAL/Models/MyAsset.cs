using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace VirtualTrading.DAL.Models
{
    [Table("MyAsset")]
    public partial class MyAsset
    {
        [Key]
        public int Id { get; set; }
        public long TradeId { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Column("stockId")]
        public int StockId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RemainingQuantity { get; set; }
        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AccountValue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTime { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Commision { get; set; }

        //[IgnoreMap]
        //public decimal profitloss { get; set; }
    }
}
