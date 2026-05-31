using HikoukiApi.Models;

namespace HikoukiApi.Dtos
{
    public class CreateAircraftSpotRequest
    {
        public DateOnly Date { get; set; }
        public int? TypeCodeVariantId { get; set; }
        public int? AirlineId { get; set; }
        public int? AirportId { get; set; }
        public required string AirportLocation { get; set; }
        public required string Camera { get; set; }
        public required string Lens { get; set; }
        public string? Remarks { get; set; }
    }
}
