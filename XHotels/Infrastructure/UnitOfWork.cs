using XHotels.Infrastructure.Interfaces;
using XHotels.Models;

namespace XHotels.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Repository<Customer> _customerRepository;
    private IRoomRepository _roomRepository;
    private Repository<Reservation> _reservationRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public Repository<Customer> CustomerRepository
    {
        get
        {
            if (_customerRepository == null)
            {
                _customerRepository = new Repository<Customer>(_context);
            }

            return _customerRepository;
        }
    }

    public IRoomRepository RoomRepository
    {
        get
        {
            if (_roomRepository == null)
            {
                _roomRepository = new RoomRepository(_context);
            }

            return _roomRepository;
        }
    }

    public Repository<Reservation> ReservationRepository
    {
        get
        {
            if (_reservationRepository == null)
            {
                _reservationRepository = new Repository<Reservation>(_context);
            }

            return _reservationRepository;
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}