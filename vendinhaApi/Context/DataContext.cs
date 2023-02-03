using Microsoft.EntityFrameworkCore;
using vendinhaApi.Models;

namespace vendinhaApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<SaleList> SaleList { get; set; }
    }
}
