using Microsoft.EntityFrameworkCore;
using VehicleAllocation.SQL.Models;

namespace VehicleAllocation.SQL
{
    public class VehicleContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleAllocationDbModel>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.VehicleReg).IsRequired();
                b.HasQueryFilter(x => !x.Archived);
                b.ToTable("VehicleAllocations");
            });
        
            modelBuilder.Entity<ParkingSpacesModel>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("ParkingSpaces");
            });
        }

        public DbSet<VehicleAllocationDbModel> VehicleAllocationModel { get; set; }
        public DbSet<ParkingSpacesModel> ParkingSpacesModel { get; set; }
    }
}
