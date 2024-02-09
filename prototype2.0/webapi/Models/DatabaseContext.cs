using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<kategori> kategoriler { get; set; }
        public DbSet<rol> roller { get; set; }
        public DbSet<urun> urunler { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}

