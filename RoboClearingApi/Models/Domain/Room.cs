using System.ComponentModel.DataAnnotations;

namespace RoboClearingApi.Models.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public List<Schedule>? Schedules { get; set; }
    }
}
