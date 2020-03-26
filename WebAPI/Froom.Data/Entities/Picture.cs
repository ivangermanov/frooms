namespace Froom.Data.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        public int ReportId { get; set; }

        public Report Report { get; set; }

        public string Link { get; set; }
    }
}