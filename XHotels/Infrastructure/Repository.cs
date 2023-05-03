using Microsoft.EntityFrameworkCore;
using XHotels.Infrastructure.Interfaces;
using XHotels.Models;
using XHotels.Models.Enums;

namespace XHotels.Infrastructure;

public class Repository<T> : IRepository<T>, IDisposable where T : BaseModel<int>, new()
{
    internal readonly DbContext _dbContext;
    private DbSet<T> dbSet;

    public DbSet<T> DbSet { get => dbSet; set => dbSet = value; }

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        DbSet = _dbContext.Set<T>();
    }

    public async Task<T> DeleteAsync(int id)
    {
        var dbSetRow = await GetByIdAsync(id);
        DbSet.Remove(dbSetRow);
        return dbSetRow;
    }

    public virtual IQueryable<T> GetAll(bool includeDeleted = false)
    {
        return DbSet.Where(x => includeDeleted || !x.IsDeleted);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        return entity;
    }

    public async Task<T> InsertAsync(T TEntity)
    {
        var entity = await DbSet.AddAsync(TEntity);
        return entity.Entity;
    }

    public T Update(T TEntity)
    {
        var entity = DbSet.Update(TEntity);
        return entity.Entity;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<object> GetByRoomTypeAsync(RoomTypeEnum bookingRoomType)
    {
        var entity = await DbSet.FindAsync(bookingRoomType);
        return entity;
    }
}

public class RoomRepository : Repository<Room>, IRoomRepository
{
    private readonly DbContext _dbContext;

    public RoomRepository(DbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<Room> GetByRoomTypeAsync(RoomTypeEnum bookingRoomType)
    {
        return await DbSet.FirstOrDefaultAsync(c => c.RoomType == bookingRoomType && c.IsAvailable);
    }
}

