namespace HikoukiApi.Models
{
    public class AircraftSpot
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public required int AircraftId { get; set; }
        public Aircraft? Aircraft { get; set; }
        public int? TypeCodeVariantId { get; set; }
        public TypeCodeVariant? TypeCodeVariant { get; set; }
        public int? AirlineId { get; set; }
        public Airline? Airline { get; set; }
        public int? AirportId { get; set; }
        public Airport? Airport { get; set; }
        public required string AirportLocation { get; set; }
        public required string Camera { get; set; }
        public required string Lens { get; set; }
        public string? Remarks { get; set; }
    }
}
