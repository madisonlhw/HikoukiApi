namespace HikoukiApi.Models
{
    public class AircraftTypeCode
    {
        public int Id { get; set; }
        public required string Icao { get; set; }
        public required string Manufacturer { get; set; }
        public ICollection<TypeCodeVariant> ModelVariants { get; set; } = [];
        public ICollection<Aircraft> Airplanes { get; set; } = [];
    }
}
