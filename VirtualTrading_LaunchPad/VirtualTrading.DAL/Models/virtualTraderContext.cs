using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

#nullable disable

namespace VirtualTrading.DAL.Models
{
    public partial class virtualTraderContext : DbContext
    {
        public virtualTraderContext()
        {
        }

        public virtualTraderContext(DbContextOptions<virtualTraderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<MyAsset> MyAssets { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockPrice> StockPrices { get; set; }
        public virtual DbSet<TradeHistory> TradeHistories { get; set; }
        public virtual DbSet<UserBalance> UserBalances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-91R08GN\\VARAD; Initial Catalog=virtualTrader2; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId).ValueGeneratedNever();

                entity.Property(e => e.CompanyName).IsFixedLength(true);

                entity.Property(e => e.Symbol).IsFixedLength(true);
            });

            modelBuilder.Entity<StockPrice>(entity =>
            {
                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.StockPrices)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockPrice_Stock");
            });

            modelBuilder.Entity<TradeHistory>(entity =>
            {
                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.TradeHistories)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TradeHistory_Stock");
            });

            modelBuilder.Entity<UserBalance>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBalances)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserBalance_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
