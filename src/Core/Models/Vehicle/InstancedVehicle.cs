using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class InstancedVehicle : IVehicle
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public long TemplateId { get; set; }
        public VehicleTemplate Template { get; set; }
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;
        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;
        public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;
        public IQueryable<PersistedActor> PersistedActors { get; set; } = null;
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        #endregion Relationship Properties

        public VehicleStaticFlags StaticFlags { get; set; } = VehicleStaticFlags.None;
        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstancedVehicle>(builder =>
            {
                builder.HasKey(nameof(InstancedVehicle.Id));

                builder
                    .HasOne(nameof(InstancedVehicle.Region))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedVehicle.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(InstancedVehicle.Template))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedVehicle.TemplateId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(InstancedVehicle.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedVehicle.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(InstancedVehicle.ParentInstancedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedVehicle.ParentInstancedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstancedVehicle>(builder =>
            {
                builder
                    .HasMany(nameof(InstancedVehicle.InstancedVehicles))
                    .WithOne(nameof(InstancedVehicle.ParentInstancedVehicle))
                    .HasForeignKey(nameof(InstancedVehicle.ParentInstancedVehicleId));

                builder
                    .HasMany(nameof(InstancedVehicle.InstancedActors))
                    .WithOne(nameof(InstancedActor.ParentInstancedVehicle))
                    .HasForeignKey(nameof(InstancedActor.ParentInstancedVehicleId));

                builder
                    .HasMany(nameof(InstancedVehicle.PersistedActors))
                    .WithOne(nameof(PersistedActor.ParentInstancedVehicle))
                    .HasForeignKey(nameof(PersistedActor.ParentInstancedVehicleId));

                builder
                    .HasMany(nameof(InstancedVehicle.InstancedItems))
                    .WithOne(nameof(InstancedItem.ParentInstancedVehicle))
                    .HasForeignKey(nameof(InstancedItem.ParentInstancedVehicleId));
            });
        }

        #endregion OnModelCreating
    }
}
