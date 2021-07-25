using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class VehiclePlacement
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public VehicleTemplate Template { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        [ForeignKey(nameof(ParentPlacedVehicle))]
        public long? ParentPlacedVehicleId { get; set; } = null;
        public VehiclePlacement ParentPlacedVehicle { get; set; } = null;

        #endregion Relationship Properties

        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;

        public int Count { get; set; }
    }

    public class VehiclePlacementEntityTypeConfiguration : IEntityTypeConfiguration<VehiclePlacement>
    {
        public void Configure(EntityTypeBuilder<VehiclePlacement> builder)
        {
            builder
                .HasOne(nameof(VehiclePlacement.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(VehiclePlacement.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(VehiclePlacement.ParentPlacedVehicle))
                .WithMany()
                .HasForeignKey(nameof(VehiclePlacement.ParentPlacedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
