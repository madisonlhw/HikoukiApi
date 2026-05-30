namespace HikoukiApi.Dtos
{
    public class CreateAircraftRequest
    {
        public required string Registration { get; set; }
        public required int AircraftTypeCodeId { get; set; }
        public int? TypeCodeVariantId { get; set; }
        public required string SerialNumber { get; set; }
        public string? LineNumber { get; set; }
        public int? AirlineId { get; set; }
        public string? AlternateOperatorName { get; set; }
        public bool IsGovOrMilitary { get; set; } = false;
        public bool IsSpecialLivery { get; set; } = false;
        public string? SpecialLiveryName { get; set; }
        public string? Remarks { get; set; }
    }
}
