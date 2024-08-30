using System.ComponentModel.DataAnnotations;

namespace RoboClearingApi.Models.Domain
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
