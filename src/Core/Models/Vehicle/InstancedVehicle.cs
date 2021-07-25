using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
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

        [InverseProperty(nameof(ParentInstancedVehicle))]
        public IQueryable<InstancedVehicle> InstancedVehicles { get; set; } = null;

        [InverseProperty(nameof(InstancedActor.ParentInstancedVehicle))]
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;

        [InverseProperty(nameof(PersistedActor.ParentInstancedVehicle))]
        public IQueryable<PersistedActor> PersistedActors { get; set; } = null;

        [InverseProperty(nameof(InstancedItem.ParentInstancedVehicle))]
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

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
