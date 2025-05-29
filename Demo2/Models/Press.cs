namespace Demo2.Models;

public class Press
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<Book>? Books { get; set; }
}
