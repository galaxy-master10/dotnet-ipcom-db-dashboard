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
            
            modelBuilder.Entity<ArticleXAvailableStock>()
                .HasKey(a => new { a.ArticleId, a.CompanyStockLocationId });

            base.OnModelCreating(modelBuilder);
        }
    }

