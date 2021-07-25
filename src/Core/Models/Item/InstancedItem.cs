using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Item
{
    public class InstancedItem : IItem
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

        [ForeignKey(nameof(ParentInstancedVehicle))]
        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;

        [ForeignKey(nameof(ParentInstancedActor))]
        public long? ParentInstancedActorId { get; set; } = null;
        public InstancedActor ParentInstancedActor { get; set; } = null;

        [ForeignKey(nameof(ParentInstancedItem))]
        public long? ParentInstancedItemId { get; set; } = null;
        public InstancedItem ParentInstancedItem { get; set; } = null;

        #endregion Relationship Properties

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }

    public class InstancedItemEntityTypeConfiguration : IEntityTypeConfiguration<InstancedItem>
    {
        public void Configure(EntityTypeBuilder<InstancedItem> builder)
        {
            builder
                .HasOne(nameof(InstancedItem.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(InstancedItem.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedItem.ParentInstancedVehicle))
                .WithMany()
                .HasForeignKey(nameof(InstancedItem.ParentInstancedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedItem.ParentInstancedActor))
                .WithMany()
                .HasForeignKey(nameof(InstancedItem.ParentInstancedActorId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedItem.ParentInstancedItem))
                .WithMany()
                .HasForeignKey(nameof(InstancedItem.ParentInstancedItemId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
