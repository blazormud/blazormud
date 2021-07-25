using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }

    public class PlacedLinkEntityTypeKeyConfiguration : IEntityTypeConfiguration<PlacedLink>
    {
        public void Configure(EntityTypeBuilder<PlacedLink> builder)
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
        }
    }

    public class PlacedLinkEntityTypeNavConfiguration : IEntityTypeConfiguration<PlacedLink>
    {
        public void Configure(EntityTypeBuilder<PlacedLink> builder) { }
    }
}
