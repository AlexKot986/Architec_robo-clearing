using RoboClearingApi.Contexts;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Services.Impl;

public class RoomRepository : IRoomRepository
{
    private readonly RoboClearingPostgreSqlDBContext _dbContext;

    public RoomRepository(RoboClearingPostgreSqlDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Add(Room room)
    {
        await _dbContext.AddAsync(room);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Room> GetById(int id)
    {
        return await _dbContext.Rooms.FindAsync(id) ?? throw new Exception($"id:{id} Not Found!");
    }

    public async Task<IEnumerable<Room>> GetAll()
    {
        return await Task.Run(() => _dbContext.Rooms);
    }

    public async Task<int> Delete(int id)
    {
        var room = await _dbContext.Rooms.FindAsync(id) ?? throw new Exception($"id:{id} Not Found!");
        _dbContext.Rooms.Remove(room);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpDate(Room room)
    {
        var check = await _dbContext.Rooms.FindAsync(room.Id) ?? throw new Exception($"id:{room.Id} Not Found!");
        check.Name = room.Name;
        return await _dbContext.SaveChangesAsync();
    }
}