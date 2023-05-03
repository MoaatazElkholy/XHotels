namespace XHotels.Models;

public class Customer : BaseModel<int>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; }
}