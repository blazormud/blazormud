using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Vehicle
{
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
                .HasOne(nameof(VehiclePlacement.ParentVehiclePlacement))
                .WithMany()
                .HasForeignKey(nameof(VehiclePlacement.ParentVehiclePlacementId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class VehiclePlacement
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Region")]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey("Template")]
        public long TemplateId { get; set; }
        public VehicleTemplate Template { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentVehiclePlacement")]
        public long? ParentVehiclePlacementId { get; set; }
        public VehiclePlacement ParentVehiclePlacement { get; set; }
    }
}
