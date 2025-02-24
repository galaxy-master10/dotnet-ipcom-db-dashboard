using EcommerceAdminBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAdminBackend.Infrastructure.Persistence.Context;



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
            
            modelBuilder.Entity<ArticlePackagingBreakdown>(entity =>
            {
                entity.ToTable("ArticlePackagingBreakdown"); // Specify the correct table name here
                entity.Property(e => e.Cubes)
                    .HasColumnType("decimal(18,2)");
            });
            
            modelBuilder.Entity<ArticleXAvailableStock>(entity =>
            {
                entity.ToTable("ArticleXAvailableStock"); // Ensure this matches the table name in the database
                entity.HasKey(a => new { a.ArticleId, a.CompanyStockLocationId });
            });

            base.OnModelCreating(modelBuilder);
        }
    }

