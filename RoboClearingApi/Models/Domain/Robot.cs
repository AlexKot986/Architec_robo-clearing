using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboClearingApi.Models.Domain
{
    public class Robot
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public string? Model { get; set; }
        public string Name { get; set; }


        public virtual RoboStatus Status { get; set; }

    }
}
