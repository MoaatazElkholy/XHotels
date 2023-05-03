using XHotels.Models;
using XHotels.Models.Enums;

namespace XHotels.Infrastructure.Interfaces;

public interface IRepository<T> where T : class, new()
{
    IQueryable<T> GetAll(bool includeDeleted = false);

    Task<T> GetByIdAsync(int id);

    Task<T> InsertAsync(T TEntity);

    T Update(T TEntity);

    Task<T> DeleteAsync(int id);
}

public interface IRoomRepository : IRepository<Room>
{ 
    Task<Room> GetByRoomTypeAsync(RoomTypeEnum bookingRoomType);
}