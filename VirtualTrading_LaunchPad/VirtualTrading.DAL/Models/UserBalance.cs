using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VirtualTrading.DAL.Models
{
    [Table("UserBalance")]
    public partial class UserBalance
    {
        [Key]
        public int UserBalanceId { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AvailableBalance { get; set; }
        [Column("lastAccess", TypeName = "datetime")]
        public DateTime? LastAccess { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.UserBalances))]
        public virtual AspNetUser User { get; set; }
    }
}
