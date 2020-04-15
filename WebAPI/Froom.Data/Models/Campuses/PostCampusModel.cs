using System.ComponentModel.DataAnnotations;

namespace Froom.Data.Models.Campuses
{
    public class PostCampusModel
    {
        [Required]
        public string Name { get; set; }
    }
}
