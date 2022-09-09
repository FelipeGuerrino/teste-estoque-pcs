using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Computer> Computers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Computer>()
            .HasData(new List<Computer>() { new Computer(1, "Acer", "Nitro 5 AN515-44", "RO Stonic RNS", 8, 512, 4.3) });
        }

    }
}