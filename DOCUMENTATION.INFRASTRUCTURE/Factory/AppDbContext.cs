using DOCUMENTATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DOCUMENTATION.INFRASTRUCTURE.Factory
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Archive> Archives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}