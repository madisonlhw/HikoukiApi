namespace HikoukiApi.Dtos
{
    public class AircraftSpotResponse
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public AircraftResponse? Aircraft { get; set; }
        public TypeCodeVariantResponse? TypeCodeVariant { get; set; }
        public AirlineResponse? Airline { get; set; }
        public AirportResponse? Airport { get; set; }
        public required string AirportLocation { get; set; }
        public required string Camera { get; set; }
        public required string Lens { get; set; }
        public string? Remarks { get; set; }
    }
}
