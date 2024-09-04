using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Models.Responses;

public class ScheduleResponce
{
    public int Id { get; set; }
    public Room Room { get; set; } = null!;
    public Robot Robot { get; set; } = null!;
    public TypeOfClearing Type { get; set; }
    public List<WeekDay> WeekDays { get; set; } = null!;
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}