using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Link;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Region
{
    public class RegionTemplate
    {
        #region Relationship Properties

        public long Id { get; set; }
        public IQueryable<AreaTemplate> Areas { get; set; } = null;
        public IQueryable<LinkTemplate> LinkTemplates { get; set; } = null;
        public IQueryable<PlacedLink> PlacedLinks { get; set; } = null;
        public IQueryable<InstancedLink> InstancedLinks { get; set; } = null;
        public IQueryable<VehicleTemplate> VehicleTemplates { get; set; } = null;
        public IQueryable<PlacedVehicle> PlacedVehicles { get; set; } = null;
        public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;
        public IQueryable<ActorTemplate> ActorTemplates { get; set; } = null;
        public IQueryable<PlacedActor> PlacedActors { get; set; } = null;
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;
        public IQueryable<ItemTemplate> ItemTemplates { get; set; } = null;
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        #endregion Relationship Properties

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegionTemplate>(builder =>
            {
                builder.HasKey(nameof(RegionTemplate.Id));
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegionTemplate>(builder =>
            {
                builder
                    .HasMany(nameof(RegionTemplate.Areas))
                    .WithOne(nameof(AreaTemplate.Region))
                    .HasForeignKey(nameof(AreaTemplate.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.LinkTemplates))
                    .WithOne(nameof(LinkTemplate.Region))
                    .HasForeignKey(nameof(LinkTemplate.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.PlacedLinks))
                    .WithOne(nameof(PlacedLink.Region))
                    .HasForeignKey(nameof(PlacedLink.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.InstancedLinks))
                    .WithOne(nameof(InstancedLink.Region))
                    .HasForeignKey(nameof(InstancedLink.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.VehicleTemplates))
                    .WithOne(nameof(VehicleTemplate.Region))
                    .HasForeignKey(nameof(VehicleTemplate.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.PlacedVehicles))
                    .WithOne(nameof(PlacedVehicle.Region))
                    .HasForeignKey(nameof(PlacedVehicle.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.InstancedVehicles))
                    .WithOne(nameof(InstancedVehicle.Region))
                    .HasForeignKey(nameof(InstancedVehicle.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.ActorTemplates))
                    .WithOne(nameof(ActorTemplate.Region))
                    .HasForeignKey(nameof(ActorTemplate.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.PlacedActors))
                    .WithOne(nameof(PlacedActor.Region))
                    .HasForeignKey(nameof(PlacedActor.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.InstancedActors))
                    .WithOne(nameof(InstancedActor.Region))
                    .HasForeignKey(nameof(InstancedActor.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.ItemTemplates))
                    .WithOne(nameof(ItemTemplate.Region))
                    .HasForeignKey(nameof(ItemTemplate.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.PlacedItems))
                    .WithOne(nameof(PlacedItem.Region))
                    .HasForeignKey(nameof(PlacedItem.RegionId));

                builder
                    .HasMany(nameof(RegionTemplate.InstancedItems))
                    .WithOne(nameof(InstancedItem.Region))
                    .HasForeignKey(nameof(InstancedItem.RegionId));
            });
        }

        #endregion OnModelCreating
    }
}
