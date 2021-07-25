using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Item
{
    public class PlacedItem
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public ItemTemplate Template { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        [ForeignKey(nameof(ParentPlacedVehicle))]
        public long? ParentPlacedVehicleId { get; set; } = null;
        public PlacedVehicle ParentPlacedVehicle { get; set; } = null;

        [ForeignKey(nameof(ParentPlacedActor))]
        public long? ParentPlacedActorId { get; set; } = null;
        public PlacedActor ParentPlacedActor { get; set; } = null;

        [ForeignKey(nameof(ParentPlacedItem))]
        public long? ParentPlacedItemId { get; set; } = null;
        public PlacedItem ParentPlacedItem { get; set; } = null;

        // [InverseProperty(nameof(ParentPlacedItem))]
        // public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        #endregion Relationship Properties

        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;

        public int Count { get; set; }
    }

    public class PlacedItemEntityTypeConfiguration : IEntityTypeConfiguration<PlacedItem>
    {
        public void Configure(EntityTypeBuilder<PlacedItem> builder)
        {
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
        }
    }
}
