namespace HikoukiApi.Dtos
{
    public class AirportResponse
    {
        public int Id { get; set; }
        public string? Iata { get; set; }
        public required string Icao { get; set; }
        public required string Name { get; set; }
        public string? AlternateName { get; set; }
        public required string Country { get; set; }
    }
}
