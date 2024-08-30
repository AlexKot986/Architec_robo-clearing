using System.ComponentModel.DataAnnotations;

namespace RoboClearingApi.Models.Domain
{
    public class WeekDay
    {
        [Key]
        public int Id { get; set; }
        public string Day { get; set; }

        public virtual List<Schedule>? Schedules { get; set; }
    }
}
