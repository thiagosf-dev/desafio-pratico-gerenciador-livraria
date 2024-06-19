namespace GestaoLivraria.Entities;

public class Book
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Stock { get; set; }
}
