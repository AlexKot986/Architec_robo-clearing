using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Models.Requests;

public class ScheduleAddRequest
{
    public int RoomId { get; set; }
    public int RobotId { get; set; }
    public TypeOfClearing Type { get; set; }
    public List<WeekDay> WeekDays { get; set; } = null!;
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}