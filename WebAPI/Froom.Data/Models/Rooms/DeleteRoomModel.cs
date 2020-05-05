using System.ComponentModel.DataAnnotations;

namespace Froom.Data.Models.Rooms
{
    public class DeleteRoomModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string FloorNumber { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public string CampusName { get; set; }
    }
}
