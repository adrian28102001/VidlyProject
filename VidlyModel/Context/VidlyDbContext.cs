using Microsoft.EntityFrameworkCore;
using VidlyModel.Models;


namespace VidlyModel.Context;

public class VidlyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    
    public VidlyDbContext()
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasOne<MembershipType>(c => c.MembershipType)
            .WithMany(a => a.Customers)
            .HasForeignKey(c=> c.MembershipTypeId);
    }
    
    public VidlyDbContext(DbContextOptions<VidlyDbContext> options) : base(options) { }
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