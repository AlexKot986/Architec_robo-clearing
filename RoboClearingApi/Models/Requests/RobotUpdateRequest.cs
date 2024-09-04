using RoboClearingApi.Models.Domain;

namespace RoboClearingApi.Models.Requests
{
    public class RobotUpdateRequest
    {
        public int Id { get; set; }
        public RoboStatus Status { get; set; }
        public string Name { get; set; } = null!;
    }
}
