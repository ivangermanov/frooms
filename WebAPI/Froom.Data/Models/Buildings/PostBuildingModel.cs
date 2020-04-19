using System.ComponentModel.DataAnnotations;

namespace Froom.Data.Models.Buildings
{
    public class PostBuildingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CampusId { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
