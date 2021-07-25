using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Item
{
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

    public class PersistedItem : IItem
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Template")]
        public long TemplateId { get; set; }
        public ItemTemplate Template { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentPersistedVehicle")]
        public long? ParentPersistedVehicleId { get; set; }
        public PersistedVehicle ParentPersistedVehicle { get; set; }

        [ForeignKey("ParentPersistedActor")]
        public long? ParentPersistedActorId { get; set; }
        public PersistedActor ParentPersistedActor { get; set; }

        [ForeignKey("ParentPersistedItem")]
        public long? ParentPersistedItemId { get; set; }
        public PersistedItem ParentPersistedItem { get; set; }

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }
}
