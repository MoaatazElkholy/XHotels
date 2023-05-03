namespace XHotels.Models;

public class Reservation : BaseModel<int>
{
    public DateTime ReservationDate { get; set; }
    public int RoomNumber { get; set; }
    public int RoomId { get; set; }
    public string CustomerName { get; set; }
    public int CustomerId { get; set; }
    public int NumberOfNights { get; set; }
    public decimal TotalPrice { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Room Room { get; set; }
}