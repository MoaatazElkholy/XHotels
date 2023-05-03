using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XHotels.Models.EntityTypeConfigurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public virtual void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Phone).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Address).HasMaxLength(200).IsRequired();
        builder.Property(p => p.DateOfBirth).IsRequired();
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.HasMany(p => p.Reservations)
            .WithOne(p => p.Customer)
            .HasForeignKey(p => p.CustomerId);
    }
}