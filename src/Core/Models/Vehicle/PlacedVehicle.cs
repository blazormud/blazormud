using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class PlacedVehicle
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public long TemplateId { get; set; }
        public VehicleTemplate Template { get; set; }
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;
        public long? ParentPlacedVehicleId { get; set; } = null;
        public PlacedVehicle ParentPlacedVehicle { get; set; } = null;
        public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;
        public IQueryable<PlacedActor> PlacedActors { get; set; } = null;
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        #endregion Relationship Properties

        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;
        public int Count { get; set; }

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacedVehicle>(builder =>
            {
                builder.HasKey(nameof(PlacedVehicle.Id));

                builder
                    .HasOne(nameof(PlacedVehicle.Region))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedVehicle.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedVehicle.Template))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedVehicle.TemplateId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedVehicle.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedVehicle.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedVehicle.ParentPlacedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedVehicle.ParentPlacedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacedVehicle>(builder =>
            {
                builder
                    .HasMany(nameof(PlacedVehicle.PlacedVehicles))
                    .WithOne(nameof(PlacedVehicle.ParentPlacedVehicle))
                    .HasForeignKey(nameof(PlacedVehicle.ParentPlacedVehicleId));

                builder
                    .HasMany(nameof(PlacedVehicle.PlacedActors))
                    .WithOne(nameof(PlacedActor.ParentPlacedVehicle))
                    .HasForeignKey(nameof(PlacedActor.ParentPlacedVehicleId));

                builder
                    .HasMany(nameof(PlacedVehicle.PlacedItems))
                    .WithOne(nameof(PlacedItem.ParentPlacedVehicle))
                    .HasForeignKey(nameof(PlacedItem.ParentPlacedVehicleId));
            });
        }

        #endregion OnModelCreating
    }
}
