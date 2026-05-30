namespace HikoukiApi.Dtos
{
    public class CreateAircraftTypeCodeRequest
    {
        public required string Icao { get; set; }
        public required string Manufacturer { get; set; }
    }
}
