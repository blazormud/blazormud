using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorMUD.Core.Models.Actor
{
    public class InstancedActor : IActor
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

        [ForeignKey(nameof(ParentInstancedVehicle))]
        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;

        [ForeignKey(nameof(ParentPersistedVehicle))]
        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;

        [InverseProperty(nameof(InstancedItem.ParentInstancedActor))]
        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        #endregion Relationship Properties

        public ActorStaticFlags StaticFlags { get; set; } = ActorStaticFlags.None;
        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;
    }

    public class InstancedActorEntityTypeConfiguration : IEntityTypeConfiguration<InstancedActor>
    {
        public void Configure(EntityTypeBuilder<InstancedActor> builder)
        {
            builder
                .HasOne(nameof(InstancedActor.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedActor.ParentPersistedVehicle))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.ParentPersistedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedActor.ParentInstancedVehicle))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.ParentInstancedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
