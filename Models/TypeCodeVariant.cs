namespace HikoukiApi.Models
{
    public class TypeCodeVariant
    {
        public int Id { get; set; }
        public required int AircraftTypeCodeId { get; set; }
        public required string VariantName { get; set; }
    }
}
