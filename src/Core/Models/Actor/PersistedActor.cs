using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Actor
{
    public class PersistedActorEntityTypeConfiguration : IEntityTypeConfiguration<PersistedActor>
    {
        public void Configure(EntityTypeBuilder<PersistedActor> builder)
        {
            builder
                .HasOne(nameof(PersistedActor.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(PersistedActor.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedActor.ParentPersistedVehicle))
                .WithMany()
                .HasForeignKey(nameof(PersistedActor.ParentPersistedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(PersistedActor.ParentVehicleInstance))
                .WithMany()
                .HasForeignKey(nameof(PersistedActor.ParentVehicleInstanceId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class PersistedActor : IActor
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        [ForeignKey("ParentArea")]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("ParentVehicleInstance")]
        public long? ParentVehicleInstanceId { get; set; }
        public VehicleInstance ParentVehicleInstance { get; set; }

        [ForeignKey("ParentPersistedVehicle")]
        public long? ParentPersistedVehicleId { get; set; }
        public PersistedVehicle ParentPersistedVehicle { get; set; }

        public ActorStaticFlags StaticFlags { get; set; }
        public ActorDynamicFlags DynamicFlags { get; set; }
    }
}
