using RoboClearingApi.Contexts;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Services.NotImpl;

public class WeekDayRepository(RoboClearingPostgreSqlDBContext _dbContext)
{
    public async Task<int> CreateDays()
    {
        var check = _dbContext.WeekDays;
        if (check.Any()) throw new Exception("WeekDays already exist");
        List<WeekDay> days =
        [
            new WeekDay { Day = "Monday" },
            new WeekDay { Day = "Tuesday" },
            new WeekDay { Day = "Wednesday" },
            new WeekDay { Day = "Thursday" },
            new WeekDay { Day = "Friday" },
            new WeekDay { Day = "Saturday" },
            new WeekDay { Day = "Sunday" }
        ];
        
        await _dbContext.WeekDays.AddRangeAsync(days);
        return await _dbContext.SaveChangesAsync();
    }
}