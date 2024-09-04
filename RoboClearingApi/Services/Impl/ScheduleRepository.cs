using RoboClearingApi.Contexts;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Services.Impl;

public class ScheduleRepository : IScheduleRepository
{
    private readonly RoboClearingPostgreSqlDBContext _dbContext;

    public ScheduleRepository(RoboClearingPostgreSqlDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Add(Schedule schedule)
    {
        await _dbContext.Schedules.AddRangeAsync(schedule);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Schedule> GetById(int id)
    {
        return await _dbContext.Schedules.FindAsync(id) ?? throw new Exception($"id:{id} Not Found");
    }

    public async Task<IEnumerable<Schedule>> GetAll()
    {
        return await Task.Run(() => _dbContext.Schedules);
    }

    public async Task<int> Delete(int id)
    {
        var schedule = await _dbContext.Schedules.FindAsync(id) ?? throw new Exception($"id:{id} Not Found");
        _dbContext.Remove(schedule);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpDate(Schedule schedule)
    {
        var check = await _dbContext.Schedules.FindAsync(schedule.Id) ??
                    throw new Exception($"id:{schedule.Id} Not Found");
        check.Room = schedule.Room;
        check.Robot = schedule.Robot;
        check.Type = schedule.Type;
        check.WeekDays = schedule.WeekDays;
        check.Start = schedule.Start;
        check.End = schedule.End;

        return await _dbContext.SaveChangesAsync();
    }
}