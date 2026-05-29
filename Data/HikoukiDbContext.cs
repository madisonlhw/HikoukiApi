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

        public DbSet<AircraftTypeCode> AircraftTypeCodes { get; set; }
        public DbSet<TypeCodeVariant> TypeCodeVariants { get; set; }
    }
}
