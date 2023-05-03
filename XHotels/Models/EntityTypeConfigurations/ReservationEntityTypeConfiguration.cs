using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XHotels.Models.EntityTypeConfigurations;

public class ReservationEntityTypeConfiguration: IEntityTypeConfiguration<Reservation>
{
    public virtual void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.CustomerId).IsRequired();
        builder.Property(p => p.RoomNumber).IsRequired();
        builder.Property(p => p.ReservationDate).IsRequired();
        builder.Property(p => p.NumberOfNights).IsRequired();
        builder.Property(p => p.TotalPrice).IsRequired();
        builder.Property(p => p.CustomerName).IsRequired();
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(p => p.Customer);
        builder.HasOne(p => p.Room);
    }
}