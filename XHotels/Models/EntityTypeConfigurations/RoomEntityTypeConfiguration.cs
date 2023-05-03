using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XHotels.Models.Enums;

namespace XHotels.Models.EntityTypeConfigurations;

public class RoomEntityTypeConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.RoomNumber).IsRequired();
        builder.Property(x => x.RoomType).IsRequired();
        builder.Property(x => x.Floor).IsRequired();
        builder.Property(x => x.NumberOfBeds).IsRequired();
        builder.Property(x => x.PricePerNight).IsRequired();
        builder.Property(e => e.IsAvailable)
            .IsRequired()
            .HasDefaultValue(true);
        builder.Property(e => e.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
        builder.HasData(
            new Room()
            {
                Id = 1,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 101,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            },
            new Room()
            {
                Id = 2,
                RoomType = RoomTypeEnum.Deluxe,
                RoomNumber = 201,
                Floor = 2,
                NumberOfBeds = 2,
                PricePerNight = 200
            },
            new Room()
            {
                Id = 3,
                RoomType = RoomTypeEnum.Suite,
                RoomNumber = 301,
                Floor = 3,
                NumberOfBeds = 3,
                PricePerNight = 300
            },
            new Room()
            {
                Id = 4,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 102,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            },
            new Room()
            {
                Id = 5,
                RoomType = RoomTypeEnum.Deluxe,
                RoomNumber = 202,
                Floor = 2,
                NumberOfBeds = 2,
                PricePerNight = 200
            },
            new Room()
            {
                Id = 6,
                RoomType = RoomTypeEnum.Suite,
                RoomNumber = 302,
                Floor = 3,
                NumberOfBeds = 3,
                PricePerNight = 300
            },
            new Room()
            {
                Id = 7,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 103,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            },
            new Room()
            {
                Id = 8,
                RoomType = RoomTypeEnum.Deluxe,
                RoomNumber = 203,
                Floor = 2,
                NumberOfBeds = 2,
                PricePerNight = 200
            },
            new Room()
            {
                Id = 9,
                RoomType = RoomTypeEnum.Suite,
                RoomNumber = 303,
                Floor = 3,
                NumberOfBeds = 3,
                PricePerNight = 300
            },
            new Room()
            {
                Id = 10,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 104,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            },
            new Room()
            {
                Id = 11,
                RoomType = RoomTypeEnum.Deluxe,
                RoomNumber = 204,
                Floor = 2,
                NumberOfBeds = 2,
                PricePerNight = 200
            },
            new Room()
            {
                Id = 12,
                RoomType = RoomTypeEnum.Suite,
                RoomNumber = 304,
                Floor = 3,
                NumberOfBeds = 3,
                PricePerNight = 300
            },
            new Room()
            {
                Id = 13,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 105,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            },
            new Room()
            {
                Id = 14,
                RoomType = RoomTypeEnum.Deluxe,
                RoomNumber = 205,
                Floor = 2,
                NumberOfBeds = 2,
                PricePerNight = 200
            },
            new Room()
            {
                Id = 15,
                RoomType = RoomTypeEnum.Suite,
                RoomNumber = 305,
                Floor = 3,
                NumberOfBeds = 3,
                PricePerNight = 300
            },
            new Room()
            {
                Id = 16,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 106,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            },
            new Room()
            {
                Id = 17,
                RoomType = RoomTypeEnum.Deluxe,
                RoomNumber = 206,
                Floor = 2,
                NumberOfBeds = 2,
                PricePerNight = 200
            },
            new Room()
            {
                Id = 18,
                RoomType = RoomTypeEnum.Suite,
                RoomNumber = 306,
                Floor = 3,
                NumberOfBeds = 3,
                PricePerNight = 300
            },
            new Room()
            {
                Id = 19,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 107,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            },
            new Room()
            {
                Id = 20,
                RoomType = RoomTypeEnum.Deluxe,
                RoomNumber = 207,
                Floor = 2,
                NumberOfBeds = 2,
                PricePerNight = 200
            },
            new Room()
            {
                Id = 21,
                RoomType = RoomTypeEnum.Suite,
                RoomNumber = 307,
                Floor = 3,
                NumberOfBeds = 3,
                PricePerNight = 300
            },
            new Room()
            {
                Id = 22,
                RoomType = RoomTypeEnum.Standard,
                RoomNumber = 108,
                Floor = 1,
                NumberOfBeds = 1,
                PricePerNight = 100
            });
    }
}