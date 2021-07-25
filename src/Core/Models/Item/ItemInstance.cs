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
    public class ItemInstanceEntityTypeConfiguration : IEntityTypeConfiguration<ItemInstance>
    {
        public void Configure(EntityTypeBuilder<ItemInstance> builder)
        {
            builder
                .HasOne(nameof(ItemInstance.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(ItemInstance.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(ItemInstance.ParentVehicleInstance))
                .WithMany()
                .HasForeignKey(nameof(ItemInstance.ParentVehicleInstanceId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(ItemInstance.ParentActorInstance))
                .WithMany()
                .HasForeignKey(nameof(ItemInstance.ParentActorInstanceId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(ItemInstance.ParentItemInstance))
                .WithMany()
                .HasForeignKey(nameof(ItemInstance.ParentItemInstanceId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ItemInstance : IItem
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Region")]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey("Template")]
        public long TemplateId { get; set; }
        public ItemTemplate Template { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentVehicleInstance")]
        public long? ParentVehicleInstanceId { get; set; }
        public VehicleInstance ParentVehicleInstance { get; set; }

        [ForeignKey("ParentActorInstance")]
        public long? ParentActorInstanceId { get; set; }
        public ActorInstance ParentActorInstance { get; set; }

        [ForeignKey("ParentItemInstance")]
        public long? ParentItemInstanceId { get; set; }
        public ItemInstance ParentItemInstance { get; set; }

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }
}
