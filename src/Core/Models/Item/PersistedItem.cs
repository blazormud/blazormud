using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Item
{
    public class PersistedItem : IItem
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long TemplateId { get; set; }
        public ItemTemplate Template { get; set; }
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;
        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;
        public long? ParentPersistedActorId { get; set; } = null;
        public PersistedActor ParentPersistedActor { get; set; } = null;
        public long? ParentPersistedItemId { get; set; } = null;
        public PersistedItem ParentPersistedItem { get; set; } = null;
        public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }

    public class PersistedItemEntityTypeKeyConfiguration : IEntityTypeConfiguration<PersistedItem>
    {
        public void Configure(EntityTypeBuilder<PersistedItem> builder)
        {
            builder.HasKey(nameof(PersistedItem.Id));

            builder
                .HasOne(nameof(PersistedItem.Template))
                .WithMany()
                .HasForeignKey(nameof(PersistedItem.TemplateId))
                .OnDelete(DeleteBehavior.Cascade);

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

    public class PersistedItemEntityTypeNavConfiguration : IEntityTypeConfiguration<PersistedItem>
    {
        public void Configure(EntityTypeBuilder<PersistedItem> builder)
        {
            builder
                .HasMany(nameof(PersistedItem.PersistedItems))
                .WithOne(nameof(PersistedItem.ParentPersistedItem))
                .HasForeignKey(nameof(PersistedItem.ParentPersistedItemId));
        }
    }
}
