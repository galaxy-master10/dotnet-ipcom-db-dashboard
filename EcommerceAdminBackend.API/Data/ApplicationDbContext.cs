using EcommerceAdminBackend.API.Models;

namespace EcommerceAdminBackend.API.Data;

using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlePackagingBreakdown> ArticlePackagingBreakdowns { get; set; }
        public DbSet<ArticleXAvailableStock> ArticleXAvailableStocks { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Articles_DE"); // Specify the table name here
                entity.Property(e => e.Diameter).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Length).HasColumnType("decimal(18,2)");
                entity.Property(e => e.R).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Thickness).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Volume).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Weight).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Width).HasColumnType("decimal(18,2)");
            });
            
            modelBuilder.Entity<ArticleXAvailableStock>()
                .HasKey(a => new { a.ArticleId, a.CompanyStockLocationId });

            base.OnModelCreating(modelBuilder);
        }
    }

