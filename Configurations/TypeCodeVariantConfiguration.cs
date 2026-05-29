using HikoukiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikoukiApi.Configurations
{
    public class TypeCodeVariantConfiguration : IEntityTypeConfiguration<TypeCodeVariant>
    {
        public void Configure(EntityTypeBuilder<TypeCodeVariant> builder)
        {
            builder.HasIndex(r => new { r.AircraftTypeCodeId, r.VariantName }).IsUnique();
        }
    }
}
