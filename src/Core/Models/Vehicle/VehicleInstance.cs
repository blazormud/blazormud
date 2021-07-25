using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class VehicleInstanceEntityTypeConfiguration : IEntityTypeConfiguration<VehicleInstance>
    {
        public void Configure(EntityTypeBuilder<VehicleInstance> builder)
        {
            builder
                .HasOne(nameof(VehicleInstance.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(VehicleInstance.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(VehicleInstance.ParentVehicleInstance))
                .WithMany()
                .HasForeignKey(nameof(VehicleInstance.ParentVehicleInstanceId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class VehicleInstance : IVehicle
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

        [ForeignKey("ParentVehicleInstance")]
        public long? ParentVehicleInstanceId { get; set; }
        public VehicleInstance ParentVehicleInstance { get; set; }

        public VehicleStaticFlags StaticFlags { get; set; } = VehicleStaticFlags.None;
        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;
    }
}
