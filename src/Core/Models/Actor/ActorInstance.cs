using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Actor
{
    public class ActorInstanceEntityTypeConfiguration : IEntityTypeConfiguration<ActorInstance>
    {
        public void Configure(EntityTypeBuilder<ActorInstance> builder)
        {
            builder
                .HasOne(nameof(ActorInstance.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(ActorInstance.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(ActorInstance.ParentPersistedVehicle))
                .WithMany()
                .HasForeignKey(nameof(ActorInstance.ParentPersistedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(ActorInstance.ParentVehicleInstance))
                .WithMany()
                .HasForeignKey(nameof(ActorInstance.ParentVehicleInstanceId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ActorInstance : IActor
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Region")]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey("Template")]
        public long TemplateId { get; set; }
        public ActorTemplate Template { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentVehicleInstance")]
        public long? ParentVehicleInstanceId { get; set; }
        public VehicleInstance ParentVehicleInstance { get; set; }

        [ForeignKey("ParentPersistedVehicle")]
        public long? ParentPersistedVehicleId { get; set; }
        public PersistedVehicle ParentPersistedVehicle { get; set; }

        public ActorStaticFlags StaticFlags { get; set; } = ActorStaticFlags.None;
        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;
    }
}
