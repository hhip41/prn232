using Microsoft.EntityFrameworkCore;
using ODataDemo.Models;

namespace ODataDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Gadget> Gadgets { get; set; }
    }
}
