using HikoukiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikoukiApi.Configurations
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.Property(r => r.Iata).HasMaxLength(2);
            builder.Property(r => r.Icao).HasMaxLength(5);
            builder.Property(r => r.Country).HasMaxLength(2);
        }
    }
}
