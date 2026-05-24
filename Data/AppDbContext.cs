using Microsoft.EntityFrameworkCore;
using GalacticNews.Models;

namespace GalacticNews.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<News>().ToTable("news");
            modelBuilder.Entity<News>().HasKey(n => n.Id);
        }
    }
}