using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboClearingApi.Models.Domain
{
    public class Robot
    {
        public int Id { get; set; }
        public RoboStatus Status { get; set; }
        public string? Model { get; set; }
        public string Name { get; set; } = null!;
    }
}
