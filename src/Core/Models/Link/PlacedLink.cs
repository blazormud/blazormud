using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Link
{
    public class PlacedLink
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public long TemplateId { get; set; }
        public LinkTemplate Template { get; set; }
        public long ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }
        public long DestinationAreaId { get; set; }
        public AreaTemplate DestinationArea { get; set; }

        #endregion Relationship Properties

        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacedLink>(builder =>
            {
                builder.HasKey(nameof(PlacedLink.Id));

                builder
                    .HasOne(nameof(PlacedLink.Region))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedLink.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedLink.Template))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedLink.TemplateId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedLink.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedLink.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PlacedLink.DestinationArea))
                    .WithMany()
                    .HasForeignKey(nameof(PlacedLink.DestinationAreaId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacedLink>(builder =>
            {

            });
        }

        #endregion OnModelCreating
    }
}
