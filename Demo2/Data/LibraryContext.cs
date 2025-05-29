using Microsoft.EntityFrameworkCore;
using Demo2.Models;

namespace Demo2.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Press> Presses => Set<Press>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Press>().HasData(
            new Press { Id = 1, Name = "Kim Đồng" },
            new Press { Id = 2, Name = "NXB Trẻ" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "OData 101", Author = "Hiệp", PressId = 1 },
            new Book { Id = 2, Title = "RESTful API", Author = "An", PressId = 2 }
        );
    }
}
