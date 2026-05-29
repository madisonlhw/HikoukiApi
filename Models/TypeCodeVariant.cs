namespace HikoukiApi.Models
{
    public class TypeCodeVariant
    {
        public int Id { get; set; }
        public required int TypeCodeId { get; set; }
        public required string VariantName { get; set; }
    }
}
