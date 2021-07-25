using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Item
{
    public class PersistedItem : IItem
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public ItemTemplate Template { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        [ForeignKey(nameof(ParentPersistedVehicle))]
        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;

        [ForeignKey(nameof(ParentPersistedActor))]
        public long? ParentPersistedActorId { get; set; } = null;
        public PersistedActor ParentPersistedActor { get; set; } = null;

        [ForeignKey(nameof(ParentPersistedItem))]
        public long? ParentPersistedItemId { get; set; } = null;
        public PersistedItem ParentPersistedItem { get; set; } = null;

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }

    public class PersistedItemEntityTypeConfiguration : IEntityTypeConfiguration<PersistedItem>
    {
        public void Configure(EntityTypeBuilder<PersistedItem> builder)
        {
            builder
                .HasOne(nameof(PersistedItem.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(PersistedItem.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedItem.ParentPersistedVehicle))
                .WithMany()
                .HasForeignKey(nameof(PersistedItem.ParentPersistedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedItem.ParentPersistedActor))
                .WithMany()
                .HasForeignKey(nameof(PersistedItem.ParentPersistedActorId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedItem.ParentPersistedItem))
                .WithMany()
                .HasForeignKey(nameof(PersistedItem.ParentPersistedItemId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
