using System.Linq;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Actor
{
    public class PlacedActor
    {
        #region Relationship Properties

        public long Id { get; set; }

        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        public long TemplateId { get; set; }
        public ActorTemplate Template { get; set; }

        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        public long? ParentPlacedVehicleId { get; set; } = null;
        public PlacedVehicle ParentPlacedVehicle { get; set; } = null;

        public IQueryable<PlacedItem> PlacedItems { get; set; } = null;

        #endregion Relationship Properties

        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;

        public int Count { get; set; } = 1;
    }

    public class PlacedActorEntityTypeKeyConfiguration : IEntityTypeConfiguration<PlacedActor>
    {
        public void Configure(EntityTypeBuilder<PlacedActor> builder)
        {
            builder.HasKey(nameof(PlacedActor.Id));

            builder
                .HasOne(nameof(PlacedActor.Region))
                .WithMany()
                .HasForeignKey(nameof(PlacedActor.RegionId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PlacedActor.Template))
                .WithMany()
                .HasForeignKey(nameof(PlacedActor.TemplateId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PlacedActor.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(PlacedActor.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PlacedActor.ParentPlacedVehicle))
                .WithMany()
                .HasForeignKey(nameof(PlacedActor.ParentPlacedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PlacedActorEntityTypeNavConfiguration : IEntityTypeConfiguration<PlacedActor>
    {
        public void Configure(EntityTypeBuilder<PlacedActor> builder)
        {
            builder
                .HasMany(nameof(PlacedActor.PlacedItems))
                .WithOne(nameof(PlacedItem.ParentPlacedActor))
                .HasForeignKey(nameof(PlacedItem.ParentPlacedActorId));
        }
    }
}
