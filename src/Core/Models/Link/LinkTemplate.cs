using System.Linq;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Link
{
    public class LinkTemplate
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public IQueryable<PlacedLink> PlacedLinks { get; set; } = null;
        public IQueryable<InstancedLink> InstancedLinks { get; set; } = null;
        public IQueryable<PersistedLink> PersistedLinks { get; set; } = null;

        #endregion Relationship Properties

        public LinkStaticFlags StaticFlags { get; set; } = LinkStaticFlags.None;
        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkTemplate>(builder =>
            {
                builder.HasKey(nameof(LinkTemplate.Id));

                builder
                    .HasOne(nameof(LinkTemplate.Region))
                    .WithMany()
                    .HasForeignKey(nameof(LinkTemplate.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkTemplate>(builder =>
            {
                builder
                    .HasMany(nameof(LinkTemplate.PlacedLinks))
                    .WithOne(nameof(PlacedLink.Template))
                    .HasForeignKey(nameof(PlacedLink.TemplateId));

                builder
                    .HasMany(nameof(LinkTemplate.InstancedLinks))
                    .WithOne(nameof(InstancedLink.Template))
                    .HasForeignKey(nameof(InstancedLink.TemplateId));

                builder
                    .HasMany(nameof(LinkTemplate.PersistedLinks))
                    .WithOne(nameof(PersistedLink.Template))
                    .HasForeignKey(nameof(PersistedLink.TemplateId));
            });
        }

        #endregion OnModelCreating
    }
}
