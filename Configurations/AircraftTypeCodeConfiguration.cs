using HikoukiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikoukiApi.Configurations
{
    public class AircraftTypeCodeConfiguration : IEntityTypeConfiguration<AircraftTypeCode>
    {
        public void Configure(EntityTypeBuilder<AircraftTypeCode> builder)
        {
            builder.HasIndex(r => r.Icao).IsUnique();
            builder.Property(r => r.Icao).HasMaxLength(4);
        }
    }
}
