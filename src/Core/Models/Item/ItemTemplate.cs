using System.Linq;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Item
{
    public class ItemTemplate
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;
        public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public ItemStaticFlags StaticFlags { get; set; } = ItemStaticFlags.None;
        public ItemDynamicFlags DynamicFlags { get; set; } = ItemDynamicFlags.None;
        public ItemWearFlags WearFlags { get; set; } = ItemWearFlags.None;
    }

    public class ItemTemplateEntityTypeKeyConfiguration : IEntityTypeConfiguration<ItemTemplate>
    {
        public void Configure(EntityTypeBuilder<ItemTemplate> builder)
        {
            builder.HasKey(nameof(ItemTemplate.Id));

            builder
                .HasOne(nameof(ItemTemplate.Region))
                .WithMany()
                .HasForeignKey(nameof(ItemTemplate.RegionId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ItemTemplateEntityTypeNavConfiguration : IEntityTypeConfiguration<ItemTemplate>
    {
        public void Configure(EntityTypeBuilder<ItemTemplate> builder)
        {
            builder
                .HasMany(nameof(ItemTemplate.PlacedItems))
                .WithOne(nameof(PlacedItem.Template))
                .HasForeignKey(nameof(PlacedItem.TemplateId));

            builder
                .HasMany(nameof(ItemTemplate.InstancedItems))
                .WithOne(nameof(InstancedItem.Template))
                .HasForeignKey(nameof(InstancedItem.TemplateId));

            builder
                .HasMany(nameof(ItemTemplate.PersistedItems))
                .WithOne(nameof(PersistedItem.Template))
                .HasForeignKey(nameof(PersistedItem.TemplateId));
        }
    }
}
