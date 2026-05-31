using HikoukiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HikoukiApi.Data
{
    public class HikoukiDbContext(DbContextOptions<HikoukiDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HikoukiDbContext).Assembly);
        }

        public DbSet<Aircraft> Airplanes => Set<Aircraft>();
        public DbSet<AircraftSpot> AircraftSpotting => Set<AircraftSpot>();
        public DbSet<AircraftTypeCode> AircraftTypeCodes => Set<AircraftTypeCode>();
        public DbSet<Airline> Airlines => Set<Airline>();
        public DbSet<Airport> Airports => Set<Airport>();
        public DbSet<TypeCodeVariant> TypeCodeVariants => Set<TypeCodeVariant>();
    }
}
