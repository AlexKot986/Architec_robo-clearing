using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboClearingApi.Models.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; } = null!;
        public int RobotId { get; set; }
        public virtual Robot Robot { get; set; } = null!;
        public TypeOfClearing Type { get; set; }
        public List<WeekDay> WeekDays { get; set; } = null!;
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
    }
}
