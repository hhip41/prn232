using System.Diagnostics;

namespace Demo2.Models;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }

    public int PressId { get; set; }
    public Press? Press { get; set; }
}
