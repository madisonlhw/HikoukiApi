using HikoukiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikoukiApi.Configurations
{
    public class AircraftSpotConfiguration : IEntityTypeConfiguration<AircraftSpot>
    {
        public void Configure(EntityTypeBuilder<AircraftSpot> builder)
        {
            builder.HasOne(a => a.Aircraft).WithMany(ac => ac.AircraftSpots).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
