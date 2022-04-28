using Microsoft.EntityFrameworkCore;
using VidlyModel.Configuration;
using VidlyModel.Models;


namespace VidlyModel.Context;

public class VidlyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Movie> Movies{ get; set; }
    public DbSet<Genre> Genres{ get; set; }
    
    public VidlyDbContext()
    {
    }

    public VidlyDbContext(DbContextOptions<VidlyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
    
}