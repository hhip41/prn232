using Microsoft.EntityFrameworkCore;

namespace FirstWebAPIProject.Db
{
    public class CodeFirstDemoContext : DbContext
    {
        public CodeFirstDemoContext(DbContextOptions<CodeFirstDemoContext> options) : base(options)
        {
        }
        public DbSet<Models.Player> Players { get; set; }
        public DbSet<Models.InstrumentType> InstrumentTypes { get; set; }
        public DbSet<Models.PlayerInstrument> PlayerInstruments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Player>()
                .HasMany(p => p.PlayerInstruments)
                .WithOne(pi => pi.Player)
                .HasForeignKey(pi => pi.PlayerId);
            modelBuilder.Entity<Models.InstrumentType>()
                .HasMany(it => it.PlayerInstruments)
                .WithOne(pi => pi.InstrumentType)
                .HasForeignKey(pi => pi.InstrumentTypeId);
        }
    }
}
