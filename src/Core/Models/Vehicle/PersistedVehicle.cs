using System.Linq;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Core.Models.Item;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Vehicle
{
    public class PersistedVehicle : IVehicle
    {
        #region Relationship Properties

        public long Id { get; set; }
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public long TemplateId { get; set; }
        public VehicleTemplate Template { get; set; }
        public long? ParentAreaId { get; set; } = null;
        public AreaTemplate ParentArea { get; set; } = null;
        public long? ParentPersistedVehicleId { get; set; } = null;
        public PersistedVehicle ParentPersistedVehicle { get; set; } = null;
        public IQueryable<PersistedVehicle> PersistedVehicles { get; set; } = null;
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;
        public IQueryable<PersistedActor> PersistedActors { get; set; } = null;
        public IQueryable<PersistedItem> PersistedItems { get; set; } = null;

        #endregion Relationship Properties

        public VehicleStaticFlags StaticFlags { get; set; } = VehicleStaticFlags.None;
        public VehicleDynamicFlags DynamicFlags { get; set; } = VehicleDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersistedVehicle>(builder =>
            {
                builder.HasKey(nameof(PersistedVehicle.Id));

                builder
                    .HasOne(nameof(PersistedVehicle.Owner))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedVehicle.OwnerId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PersistedVehicle.Template))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedVehicle.TemplateId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PersistedVehicle.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedVehicle.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                builder
                    .HasOne(nameof(PersistedVehicle.ParentPersistedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedVehicle.ParentPersistedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersistedVehicle>(builder =>
            {
                builder
                    .HasMany(nameof(PersistedVehicle.PersistedVehicles))
                    .WithOne(nameof(PersistedVehicle.ParentPersistedVehicle))
                    .HasForeignKey(nameof(PersistedVehicle.ParentPersistedVehicleId));

                builder
                    .HasMany(nameof(PersistedVehicle.InstancedActors))
                    .WithOne(nameof(InstancedActor.ParentPersistedVehicle))
                    .HasForeignKey(nameof(InstancedActor.ParentPersistedVehicleId));

                builder
                    .HasMany(nameof(PersistedVehicle.PersistedActors))
                    .WithOne(nameof(PersistedActor.ParentPersistedVehicle))
                    .HasForeignKey(nameof(PersistedActor.ParentPersistedVehicleId));

                builder
                    .HasMany(nameof(PersistedVehicle.PersistedItems))
                    .WithOne(nameof(PersistedItem.ParentPersistedVehicle))
                    .HasForeignKey(nameof(PersistedItem.ParentPersistedVehicleId));
            });
        }

        #endregion OnModelCreating
    }
}
