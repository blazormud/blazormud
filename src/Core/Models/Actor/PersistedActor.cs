using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Actor
{
    public class PersistedActor : IActor
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey(nameof(ParentInstancedVehicle))]
        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;

        [ForeignKey(nameof(ParentPersistedVehicle))]
        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;

        // [InverseProperty(nameof(PersistedItem.ParentPersistedActor))]
        // public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public ActorStaticFlags StaticFlags { get; set; } = ActorStaticFlags.None;
        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;
    }

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
                .HasOne(nameof(PersistedActor.ParentInstancedVehicle))
                .WithMany()
                .HasForeignKey(nameof(PersistedActor.ParentInstancedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
