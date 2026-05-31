using HikoukiApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikoukiApi.Configurations
{
    public class AircraftConfiguration : IEntityTypeConfiguration<Aircraft>
    {
        public void Configure(EntityTypeBuilder<Aircraft> builder)
        {
            builder.HasOne(a => a.TypeCode).WithMany(tc => tc.Airplanes).OnDelete(DeleteBehavior.Restrict);   
        }
    }
}
