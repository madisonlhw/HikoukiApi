namespace HikoukiApi.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public required string Registration { get; set; }
        public int AircraftTypeCodeId { get; set; }
        public AircraftTypeCode? TypeCode { get; set; }
        public int? TypeCodeVariantId { get; set; }
        public TypeCodeVariant? TypeCodeVariant { get; set; }
        public required string SerialNumber { get; set; }
        public string? LineNumber { get; set; }
        public int? AirlineId { get; set; }
        public Airline? Airline { get; set; }
        /// <summary>
        /// Name of the aircraft operator in the event it does not have an airline code.
        /// </summary>
        public string? AlternateOperatorName { get; set; }
        public bool IsGovOrMilitary { get; set; } = false;
        public bool IsSpecialLivery { get; set; } = false;
        public string? SpecialLiveryName { get; set; }
        public string? Remarks { get; set; }
        public ICollection<AircraftSpot> AircraftSpots { get; set; } = [];
    }
}
