using System.Linq;
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

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public long TemplateId { get; set; }
        public ItemTemplate Template { get; set; }
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;
        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;
        public long? ParentInstancedActorId { get; set; } = null;
        public InstancedActor ParentInstancedActor { get; set; } = null;
        public long? ParentInstancedItemId { get; set; } = null;
        public InstancedItem ParentInstancedItem { get; set; } = null;
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        #endregion Relationship Properties

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }

    public class InstancedItemEntityTypeKeyConfiguration : IEntityTypeConfiguration<InstancedItem>
    {
        public void Configure(EntityTypeBuilder<InstancedItem> builder)
        {
            builder.HasKey(nameof(InstancedItem.Id));

            builder
                .HasOne(nameof(InstancedItem.Region))
                .WithMany()
                .HasForeignKey(nameof(InstancedItem.RegionId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedItem.Template))
                .WithMany()
                .HasForeignKey(nameof(InstancedItem.TemplateId))
                .OnDelete(DeleteBehavior.Cascade);

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

    public class InstancedItemEntityTypeNavConfiguration : IEntityTypeConfiguration<InstancedItem>
    {
        public void Configure(EntityTypeBuilder<InstancedItem> builder)
        {
            builder
                .HasMany(nameof(InstancedItem.InstancedItems))
                .WithOne(nameof(InstancedItem.ParentInstancedItem))
                .HasForeignKey(nameof(InstancedItem.ParentInstancedItemId));
        }
    }
}
