using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using XHotels.Models.Enums;

namespace XHotels.Models.Wizard;

[Serializable]
public class BookingViewModel
{
    // Step 1: Customer Information
    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your address.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Please enter your phone number.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your date of birth.")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    // Step 2: Room Selection
    [Required(ErrorMessage = "Please select a room type.")]
    public int RoomType { get; set; }


    [Required(ErrorMessage = "Please enter a reservation date.")]
    [DataType(DataType.Date)]
    public DateTime ReservationDate { get; set; }

    [Required(ErrorMessage = "Please enter the number of nights.")]
    [Range(1, 30, ErrorMessage = "Please enter a value between 1 and 30.")]
    public int NumberOfNights { get; set; }
}