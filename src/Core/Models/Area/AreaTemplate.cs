using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Link;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Area
{
    public class AreaTemplate
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public IQueryable<PlacedLink> PlacedLinks { get; set; } = null;
        public IQueryable<PlacedLink> DestinationPlacedLinks { get; set; } = null;
        public IQueryable<InstancedLink> InstancedLinks { get; set; } = null;
        public IQueryable<InstancedLink> DestinationInstancedLinks { get; set; } = null;
        public IQueryable<PersistedLink> PersistedLinks { get; set; } = null;
        public IQueryable<PersistedLink> DestinationPersistedLinks { get; set; } = null;
        public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;
        public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;
        public IQueryable<PersistedVehicle> PersistedVehicles { get; set; } = null;
        public IQueryable<PlacedActor> PlacedActors { get; set; } = null;
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;
        public IQueryable<PersistedActor> PersistedActors { get; set; } = null;
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;
        public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public string Name { get; set; }
        public string Notes { get; set; }
        public AreaFlags Flags { get; set; } = AreaFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaTemplate>(builder =>
            {
                builder.HasKey(nameof(AreaTemplate.Id));

                builder
                    .HasOne(nameof(AreaTemplate.Region))
                    .WithMany()
                    .HasForeignKey(nameof(AreaTemplate.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaTemplate>(builder =>
            {
                builder
                    .HasMany(nameof(AreaTemplate.PlacedLinks))
                    .WithOne(nameof(PlacedLink.ParentArea))
                    .HasForeignKey(nameof(PlacedLink.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.DestinationPlacedLinks))
                    .WithOne(nameof(PlacedLink.DestinationArea))
                    .HasForeignKey(nameof(PlacedLink.DestinationAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.InstancedLinks))
                    .WithOne(nameof(InstancedLink.ParentArea))
                    .HasForeignKey(nameof(InstancedLink.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.DestinationInstancedLinks))
                    .WithOne(nameof(InstancedLink.DestinationArea))
                    .HasForeignKey(nameof(InstancedLink.DestinationAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.PersistedLinks))
                    .WithOne(nameof(PersistedLink.ParentArea))
                    .HasForeignKey(nameof(PersistedLink.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.DestinationPersistedLinks))
                    .WithOne(nameof(PersistedLink.DestinationArea))
                    .HasForeignKey(nameof(PersistedLink.DestinationAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.PlacedVehicles))
                    .WithOne(nameof(PlacedVehicle.ParentArea))
                    .HasForeignKey(nameof(PlacedVehicle.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.InstancedVehicles))
                    .WithOne(nameof(InstancedVehicle.ParentArea))
                    .HasForeignKey(nameof(InstancedVehicle.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.PersistedVehicles))
                    .WithOne(nameof(PersistedVehicle.ParentArea))
                    .HasForeignKey(nameof(PersistedVehicle.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.PlacedActors))
                    .WithOne(nameof(PlacedActor.ParentArea))
                    .HasForeignKey(nameof(PlacedActor.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.InstancedActors))
                    .WithOne(nameof(InstancedActor.ParentArea))
                    .HasForeignKey(nameof(InstancedActor.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.PersistedActors))
                    .WithOne(nameof(PersistedActor.ParentArea))
                    .HasForeignKey(nameof(PersistedActor.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.PlacedItems))
                    .WithOne(nameof(PlacedItem.ParentArea))
                    .HasForeignKey(nameof(PlacedItem.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.InstancedItems))
                    .WithOne(nameof(InstancedItem.ParentArea))
                    .HasForeignKey(nameof(InstancedItem.ParentAreaId));

                builder
                    .HasMany(nameof(AreaTemplate.PersistedItems))
                    .WithOne(nameof(PersistedItem.ParentArea))
                    .HasForeignKey(nameof(PersistedItem.ParentAreaId));
            });
        }

        #endregion OnModelCreating
    }
}
