using CQRSPlayerDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSPlayerDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
    }
}
