using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XHotels.Models.EntityTypeConfigurations;

public class RoomTypeEntityTypeConfiguration: IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasData(
            new RoomType()
            {
                Id = 1,
                Name = "Standard",
                Details = "A standard Room with basic amenities"
            },
            new RoomType()
            {
                Id = 2,
                Name = "Deluxe",
                Details = "A deluxe Room with luxurious amenities"
            },
            new RoomType()
            {
                Id = 3,
                Name = "Suite",
                Details = "A suite with the best amenities"
            });
    }
}