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

        public long Id { get; set; }

        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        public long TemplateId { get; set; }
        public ActorTemplate Template { get; set; }

        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;

        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;

        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;

        public IQueryable<InstancedItem> InstancedItems { get; set; } = null;

        #endregion Relationship Properties

        public ActorStaticFlags StaticFlags { get; set; } = ActorStaticFlags.None;
        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;
    }

    public class InstancedActorEntityTypeKeyConfiguration : IEntityTypeConfiguration<InstancedActor>
    {
        public void Configure(EntityTypeBuilder<InstancedActor> builder)
        {
            builder.HasKey(nameof(InstancedActor.Id));

            builder
                .HasOne(nameof(InstancedActor.Region))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.RegionId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedActor.Template))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.TemplateId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedActor.ParentArea))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.ParentAreaId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedActor.ParentInstancedVehicle))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.ParentInstancedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(nameof(InstancedActor.ParentPersistedVehicle))
                .WithMany()
                .HasForeignKey(nameof(InstancedActor.ParentPersistedVehicleId))
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class InstancedActorEntityTypeNavConfiguration : IEntityTypeConfiguration<InstancedActor>
    {
        public void Configure(EntityTypeBuilder<InstancedActor> builder)
        {
            builder
                .HasMany(nameof(InstancedActor.InstancedItems))
                .WithOne(nameof(InstancedItem.ParentInstancedActor))
                .HasForeignKey(nameof(InstancedItem.ParentInstancedActorId));
        }
    }
}
