namespace HikoukiApi.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string? Iata { get; set; }
        public required string Icao { get; set; }
        public required string Name { get; set; }
        public required string Country { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
