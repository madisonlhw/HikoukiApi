using HikoukiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikoukiApi.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasIndex(r => r.Iata).IsUnique();
            builder.Property(r => r.Iata).HasMaxLength(3);

            builder.HasIndex(r => r.Icao).IsUnique();
            builder.Property(r => r.Icao).HasMaxLength(4);

            builder.Property(r => r.Country).HasMaxLength(2);
        }
    }
}
