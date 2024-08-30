namespace RoboClearingApi.Models.Requests
{
    public class RobotUpdateRequest
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        //public string? Model { get; set; }
        public string Name { get; set; }
    }
}
