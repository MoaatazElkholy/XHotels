using XHotels.Models.Enums;

namespace XHotels.Models;

public class Room : BaseModel<int>
{
    public int RoomNumber { get; set; }
    public RoomTypeEnum RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public int Floor { get; set; }
    public int NumberOfBeds { get; set; }
    public bool IsAvailable { get; set; }
}