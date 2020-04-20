namespace Froom.Data.Dtos
{
    public class CampusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of CampusDto.
        /// </summary>
        public CampusDto() { }
    }
}
