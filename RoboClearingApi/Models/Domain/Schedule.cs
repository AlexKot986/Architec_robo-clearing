using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboClearingApi.Models.Domain
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        [ForeignKey("Robot")]
        public int RobotId { get; set; }
        [ForeignKey("TypeOfClearing")]
        public int TypeOfClearingId { get; set; }
        [ForeignKey("WeekDay")]
        public List<int> WeekDaysId { get; set; }
        public TimeOnly StartClearing { get; set; }
        public TimeOnly EndClearing { get; set; }

        public virtual Room Room { get; set; }
        public virtual Robot Robot { get; set; }
        public virtual TypeOfClearing TypeOfClearing { get; set; }
        public virtual List<WeekDay> WeekDayList { get; set; } = new List<WeekDay>();

    }
}
