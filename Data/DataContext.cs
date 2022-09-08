using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Computer>()
            .HasData(new List<Computer>() { new Computer(1, "Acer", "Nitro 5 AN515-44", "RO Stonic RNS", 8, 512, 4.3) });
        }

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

    }
}