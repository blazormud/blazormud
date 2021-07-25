using System.Linq;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Actor
{
    public class PersistedActor : IActor
    {
        #region Relationship Properties

        public long Id { get; set; }

        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public long? ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        public long? ParentInstancedVehicleId { get; set; } = null;
        public InstancedVehicle ParentInstancedVehicle { get; set; } = null;

        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;

        public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public ActorStaticFlags StaticFlags { get; set; } = ActorStaticFlags.None;
        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersistedActor>(builder =>
            {
                builder.HasKey(nameof(PersistedActor.Id));

                builder
                    .HasOne(nameof(PersistedActor.Owner))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedActor.OwnerId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PersistedActor.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedActor.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PersistedActor.ParentInstancedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedActor.ParentInstancedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PersistedActor.ParentPersistedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedActor.ParentPersistedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersistedActor>(builder =>
            {
                builder
                    .HasMany(nameof(PersistedActor.PersistedItems))
                    .WithOne(nameof(PersistedItem.ParentPersistedActor))
                    .HasForeignKey(nameof(PersistedItem.ParentPersistedActorId));
            });
        }

        #endregion OnModelCreating
    }
}
