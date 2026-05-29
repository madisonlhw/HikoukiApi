namespace HikoukiApi.Models
{
    public class TypeCode
    {
        public int Id { get; set; }
        public required string Icao { get; set; }
        public required string Manufacturer { get; set; }
        public ICollection<TypeCodeVariant> ModelVariants { get; set; } = [];
    }
}
