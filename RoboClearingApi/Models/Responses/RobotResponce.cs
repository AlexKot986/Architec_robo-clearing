using System.ComponentModel.DataAnnotations.Schema;

namespace RoboClearingApi.Models.Responses
{
    public class RobotResponce
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string? Model { get; set; }
        public string Name { get; set; }
    }
}
