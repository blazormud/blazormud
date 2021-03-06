using System.Linq;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class VehicleTemplate
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;
        public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;
        public IQueryable<PersistedVehicle> PersistedVehicles { get; set; } = null;

        #endregion Relationship Properties

        public VehicleStaticFlags StaticFlags { get; set; } = VehicleStaticFlags.None;
        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleTemplate>(builder =>
            {
                builder.HasKey(nameof(VehicleTemplate.Id));

                builder
                    .HasOne(nameof(VehicleTemplate.Region))
                    .WithMany()
                    .HasForeignKey(nameof(VehicleTemplate.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleTemplate>(builder =>
            {
                builder
                    .HasMany(nameof(VehicleTemplate.PlacedVehicles))
                    .WithOne(nameof(PlacedVehicle.Template))
                    .HasForeignKey(nameof(PlacedVehicle.TemplateId));

                builder
                    .HasMany(nameof(VehicleTemplate.InstancedVehicles))
                    .WithOne(nameof(InstancedVehicle.Template))
                    .HasForeignKey(nameof(InstancedVehicle.TemplateId));

                builder
                    .HasMany(nameof(VehicleTemplate.PersistedVehicles))
                    .WithOne(nameof(PersistedVehicle.Template))
                    .HasForeignKey(nameof(PersistedVehicle.TemplateId));
            });
        }

        #endregion OnModelCreating
    }
}
