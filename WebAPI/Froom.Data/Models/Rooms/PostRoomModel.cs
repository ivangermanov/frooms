using Froom.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Froom.Data.Models.Rooms
{
    public class PostRoomModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string FloorNumber { get; set; }
        [Required]
        public string CampusName { get; set; }
        [Required]
        public string BuildingName { get; set; }
        public int? Capacity { get; set; }
        [Required]
        public ICollection<Point> Points { get; set; }
    }
}
