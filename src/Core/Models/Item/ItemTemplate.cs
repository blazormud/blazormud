using System.Linq;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

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

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemTemplate>(builder =>
            {
                builder.HasKey(nameof(ItemTemplate.Id));

                builder
                    .HasOne(nameof(ItemTemplate.Region))
                    .WithMany()
                    .HasForeignKey(nameof(ItemTemplate.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemTemplate>(builder =>
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
            });
        }

        #endregion OnModelCreating
    }
}
