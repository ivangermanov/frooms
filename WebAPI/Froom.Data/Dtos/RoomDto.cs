namespace Froom.Data.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public string BuildingName { get; set; }

        public string CampusName { get; set; }

        public string FloorNumber { get; set; }

        public int? Capacity { get; set; }
    }
}