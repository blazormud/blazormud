using BlazorMUD.Core.Models.Area;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Link
{
    public class PersistedLink : ILink
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long TemplateId { get; set; }
        public LinkTemplate Template { get; set; }
        public long ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }
        public long DestinationAreaId { get; set; }
        public AreaTemplate DestinationArea { get; set; }

        #endregion Relationship Properties

        public LinkStaticFlags StaticFlags { get; set; } = LinkStaticFlags.None;
        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;
    }

    public class PersistedLinkEntityTypeKeyConfiguration : IEntityTypeConfiguration<PersistedLink>
    {
        public void Configure(EntityTypeBuilder<PersistedLink> builder)
        {
            builder.HasKey(nameof(PersistedLink.Id));

            builder
                .HasOne(nameof(PersistedLink.Template))
                .WithMany()
                .HasForeignKey(nameof(PersistedLink.TemplateId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedLink.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(PersistedLink.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedLink.DestinationArea))
                .WithMany()
                .HasForeignKey(nameof(PersistedLink.DestinationAreaId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PersistedLinkEntityTypeNavConfiguration : IEntityTypeConfiguration<PersistedLink>
    {
        public void Configure(EntityTypeBuilder<PersistedLink> builder) { }
    }
}
