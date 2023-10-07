using GetItFreshApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetItFreshApi.DatabaseManagement
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet <Farmer> Farmers { get; set; }
        public DbSet <Merchant> Merchants { get; set; }
        public DbSet<Pricing> Pricing { get; set; }
        public DbSet <Transaction> Transaction { get; set; }
        public DbSet<User> Users { get; set; }
    } 
}
