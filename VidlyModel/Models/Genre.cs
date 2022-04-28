namespace VidlyModel.Models;

public class Genre
{
    public byte Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}