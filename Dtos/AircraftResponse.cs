namespace HikoukiApi.Dtos
{
    public class AircraftResponse
    {
        public int Id { get; set; }
        public required string Registration { get; set; }
        public AircraftTypeCodeResponse? TypeCode { get; set; }
        public TypeCodeVariantResponse? TypeCodeVariant { get; set; }
        public required string SerialNumber { get; set; }
        public string? LineNumber { get; set; }
        public AirlineResponse? Airline { get; set; }
        public string? AlternateOperatorName { get; set; }
        public bool IsGovOrMilitary { get; set; } = false;
        public bool IsSpecialLivery { get; set; } = false;
        public string? SpecialLiveryName { get; set; }
        public string? Remarks { get; set; }
    }
}
