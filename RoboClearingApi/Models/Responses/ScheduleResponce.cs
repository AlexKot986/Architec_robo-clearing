namespace RoboClearingApi.Models.Responses;

public class ScheduleResponce
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int RobotId { get; set; }
    public int TypeOfClearingId { get; set; }
    public List<int> WeekDaysId { get; set; }
    public TimeOnly StartClearing { get; set; }
    public TimeOnly EndClearing { get; set; }
}