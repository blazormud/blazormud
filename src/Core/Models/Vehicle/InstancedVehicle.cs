using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class InstancedVehicle : IVehicle
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

        [ForeignKey(nameof(ParentInstancedVehicle))]
        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;

        #endregion Relationship Properties

        public VehicleStaticFlags StaticFlags { get; set; } = VehicleStaticFlags.None;
        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;
    }

    public class InstancedVehicleEntityTypeConfiguration : IEntityTypeConfiguration<InstancedVehicle>
    {
        public void Configure(EntityTypeBuilder<InstancedVehicle> builder)
        {
            builder
                .HasOne(nameof(InstancedVehicle.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(InstancedVehicle.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedVehicle.ParentInstancedVehicle))
                .WithMany()
                .HasForeignKey(nameof(InstancedVehicle.ParentInstancedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
