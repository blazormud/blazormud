using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Actor
{
    public class PlacedActor
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public ActorTemplate Template { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        [ForeignKey(nameof(ParentPlacedVehicle))]
        public long? ParentPlacedVehicleId { get; set; } = null;
        public VehiclePlacement ParentPlacedVehicle { get; set; } = null;

        #endregion Relationship Properties

        public ActorDynamicFlags DynamicFlags { get; set; }

        public int Count { get; set; }
    }

    public class PlacedActorEntityTypeConfiguration : IEntityTypeConfiguration<PlacedActor>
    {
        public void Configure(EntityTypeBuilder<PlacedActor> builder)
        {
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
}
