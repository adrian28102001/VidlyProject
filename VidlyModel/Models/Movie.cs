namespace VidlyModel.Models;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime ReleaseDate { get; set; }
    public byte NumberInStock { get; set; }
    public virtual Genre Genre { get; set; }
    public byte GenreId { get; set; }
}