using System.ComponentModel.DataAnnotations.Schema;
using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Models.Responses
{
    public class RobotResponce
    {
        public int Id { get; set; }
        public RoboStatus Status { get; set; }
        public string? Model { get; set; }
        public string Name { get; set; } = null!;
    }
}
