using XHotels.Models;

namespace XHotels.Infrastructure.Interfaces;

public interface IUnitOfWork
{
    Repository<Customer> CustomerRepository
    { 
        get; 
    }
    
    IRoomRepository RoomRepository
    { 
        get; 
    }
    
    Repository<Reservation> ReservationRepository
    { 
        get; 
    }
    
    Task SaveChangesAsync();
}