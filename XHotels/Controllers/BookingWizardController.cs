using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XHotels.Infrastructure.Interfaces;
using XHotels.Models;
using XHotels.Models.Enums;
using XHotels.Models.ViewModels;

namespace XHotels.Controllers;

public class BookingWizardController : Controller
{
    private readonly IUnitOfWork _unitOfWork;


    public BookingWizardController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View("_CustomerInformation", new BookingViewModel());
    }

    [HttpPost]
    public IActionResult Index(BookingViewModel model)
    {
        if (ModelState["Name"].Errors.Any() || ModelState["Address"].Errors.Any() || ModelState["Email"].Errors.Any() || ModelState["Phone"].Errors.Any() || ModelState["DateOfBirth"].Errors.Any())
        {
            return View("_CustomerInformation", model);
        }

        var serializedModel = JsonConvert.SerializeObject(model);

        TempData["booking"] = serializedModel;

        return RedirectToAction("RoomInformation");
    }

    public IActionResult RoomInformation()
    {
        var serializedBooking = TempData.Peek("booking") as string;

        if (serializedBooking == null)
        {
            return RedirectToAction("Index");
        }

        var booking = JsonConvert.DeserializeObject<BookingViewModel>(serializedBooking);
        return View("_RoomSelection", booking);
    }


    [HttpPost]
    public async Task<IActionResult> RoomInformation(BookingViewModel model)
    {
        if (ModelState["NumberOfNights"].Errors.Any() || ModelState["ReservationDate"].Errors.Any() || ModelState["RoomType"].Errors.Any())
        {
            return View("_RoomSelection", model);
        }

        var booking = JsonConvert.DeserializeObject<BookingViewModel>(TempData["booking"] as string);
        if (booking == null)
        {
            return RedirectToAction("Index");
        }

        booking.Name = booking.Name;
        booking.Email = booking.Email;
        booking.Phone = booking.Phone;
        booking.Address = booking.Address;
        booking.DateOfBirth = booking.DateOfBirth;
        booking.RoomType = model.RoomType;
        booking.ReservationDate = model.ReservationDate;
        booking.NumberOfNights = model.NumberOfNights;


        var customer = new Customer
        {
            Name = booking.Name,
            Address = booking.Address,
            Email = booking.Email,
            Phone = booking.Phone,
            DateOfBirth = booking.DateOfBirth
        };

        var room = await _unitOfWork.RoomRepository.GetByRoomTypeAsync((RoomTypeEnum)booking.RoomType);

        await _unitOfWork.CustomerRepository.InsertAsync(customer);
        await _unitOfWork.SaveChangesAsync();

        var reservation = new Reservation
        {
            CustomerId = customer.Id,
            CustomerName = customer.Name,
            RoomNumber = room.RoomNumber,
            RoomId = room.Id,
            ReservationDate = booking.ReservationDate,
            NumberOfNights = booking.NumberOfNights,
            TotalPrice = room.PricePerNight * booking.NumberOfNights
        };
        await _unitOfWork.ReservationRepository.InsertAsync(reservation);
        await _unitOfWork.SaveChangesAsync();


        TempData["booking"] = JsonConvert.SerializeObject(booking);
        return RedirectToAction("CompleteReservation");
    }

    public IActionResult CompleteReservation()
    {
        var serializedBooking = TempData.Peek("booking") as string;
        if (serializedBooking == null)
        {
            return RedirectToAction("Index");
        }

        var booking = JsonConvert.DeserializeObject<BookingViewModel>(serializedBooking);
        return View("_Confirmation", booking);
    }
}