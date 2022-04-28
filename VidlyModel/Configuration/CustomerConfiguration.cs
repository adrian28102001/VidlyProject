using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VidlyModel.Models;

namespace VidlyModel.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasOne<MembershipType>(c => c.MembershipType)
            .WithMany(a => a.Customers)
            .HasForeignKey(c => c.MembershipTypeId);
        
    }
}