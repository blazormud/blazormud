using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Link
{
    public class InstancedLink : ILink
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

        public LinkStaticFlags StaticFlags { get; set; } = LinkStaticFlags.None;
        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstancedLink>(builder =>
            {
                builder.HasKey(nameof(InstancedLink.Id));

                builder
                    .HasOne(nameof(InstancedLink.Region))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedLink.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(InstancedLink.Template))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedLink.TemplateId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(InstancedLink.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedLink.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(InstancedLink.DestinationArea))
                    .WithMany()
                    .HasForeignKey(nameof(InstancedLink.DestinationAreaId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstancedLink>(builder =>
            {

            });
        }

        #endregion OnModelCreating
    }
}
