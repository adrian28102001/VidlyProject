using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VidlyModel.Models;

namespace VidlyModel.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .HasOne<Genre>(c => c.Genre)
            .WithMany(a => a.Movies)
            .HasForeignKey(c => c.GenreId);
    }
}