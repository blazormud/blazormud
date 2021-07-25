using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Item
{
    public class PlacedItem
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public long TemplateId { get; set; }
        public ItemTemplate Template { get; set; }
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;
        public long? ParentPlacedVehicleId { get; set; } = null;
        public PlacedVehicle ParentPlacedVehicle { get; set; } = null;
        public long? ParentPlacedActorId { get; set; } = null;
        public PlacedActor ParentPlacedActor { get; set; } = null;
        public long? ParentPlacedItemId { get; set; } = null;
        public PlacedItem ParentPlacedItem { get; set; } = null;
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        #endregion Relationship Properties

        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public int Count { get; set; }

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacedItem>(builder =>
            {
                builder.HasKey(nameof(PlacedItem.Id));

                builder
                    .HasOne(nameof(PlacedItem.Region))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedItem.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedItem.Template))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedItem.TemplateId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedItem.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedItem.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedItem.ParentPlacedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedItem.ParentPlacedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedItem.ParentPlacedActor))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedItem.ParentPlacedActorId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedItem.ParentPlacedItem))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedItem.ParentPlacedItemId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacedItem>(builder =>
            {
                builder
                    .HasMany(nameof(PlacedItem.PlacedItems))
                    .WithOne(nameof(PlacedItem.ParentPlacedItem))
                    .HasForeignKey(nameof(PlacedItem.ParentPlacedItemId));
            });
        }

        #endregion OnModelCreating
    }
}
