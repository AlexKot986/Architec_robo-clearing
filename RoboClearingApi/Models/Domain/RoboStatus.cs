using System.ComponentModel.DataAnnotations;

namespace RoboClearingApi.Models.Domain
{
    public class RoboStatus
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual List<Robot>? Robots { get; set; }
    }
}
