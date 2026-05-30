namespace HikoukiApi.Dtos
{
    public class AircraftTypeCodeResponse
    {
        public int Id { get; set; }
        public required string Icao { get; set; }
        public required string Manufacturer { get; set; }
    }
}
