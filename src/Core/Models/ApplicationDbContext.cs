using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Link;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorMUD.Core.Models
{
    public class ApplicationDbContext : KeyApiAuthorizationDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions) { }

        public DbSet<RegionTemplate> Regions { get; set; }
        public DbSet<AreaTemplate> Areas { get; set; }

        public DbSet<LinkTemplate> LinkTemplates { get; set; }
        public DbSet<LinkPlacement> LinkPlacements { get; set; }
        public DbSet<LinkInstance> LinkInstances { get; set; }
        public DbSet<PersistedLink> PersistedLinks { get; set; }

        public DbSet<VehicleTemplate> VehicleTemplates { get; set; }
        public DbSet<VehiclePlacement> VehiclePlacements { get; set; }
        public DbSet<VehicleInstance> VehicleInstances { get; set; }
        public DbSet<PersistedVehicle> PersistedVehicles { get; set; }

        public DbSet<ActorTemplate> ActorTemplates { get; set; }
        public DbSet<ActorPlacement> ActorPlacements { get; set; }
        public DbSet<ActorInstance> ActorInstances { get; set; }
        public DbSet<PersistedActor> PersistedActors { get; set; }

        public DbSet<ItemTemplate> ItemTemplates { get; set; }
        public DbSet<ItemPlacement> ItemPlacements { get; set; }
        public DbSet<ItemInstance> ItemInstances { get; set; }
        public DbSet<PersistedItem> PersistedItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehiclePlacement>(bldr =>
            {
                bldr.HasOne(nameof(VehiclePlacement.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(VehiclePlacement.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(VehiclePlacement.ParentVehiclePlacement))
                    .WithMany()
                    .HasForeignKey(nameof(VehiclePlacement.ParentVehiclePlacementId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<VehicleInstance>(bldr =>
            {
                bldr.HasOne(nameof(VehicleInstance.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(VehicleInstance.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(VehicleInstance.ParentVehicleInstance))
                    .WithMany()
                    .HasForeignKey(nameof(VehicleInstance.ParentVehicleInstanceId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PersistedVehicle>(bldr =>
            {
                bldr.HasOne(nameof(PersistedVehicle.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedVehicle.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(PersistedVehicle.ParentPersistedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedVehicle.ParentPersistedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ActorInstance>(bldr =>
            {
                bldr.HasOne(nameof(ActorInstance.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(ActorInstance.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ActorInstance.ParentPersistedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(ActorInstance.ParentPersistedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ActorInstance.ParentVehicleInstance))
                    .WithMany()
                    .HasForeignKey(nameof(ActorInstance.ParentVehicleInstanceId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PersistedActor>(bldr =>
            {
                bldr.HasOne(nameof(PersistedActor.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedActor.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(PersistedActor.ParentPersistedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedActor.ParentPersistedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(PersistedActor.ParentVehicleInstance))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedActor.ParentVehicleInstanceId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ActorPlacement>(bldr =>
            {
                bldr.HasOne(nameof(ActorPlacement.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(ActorPlacement.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ActorPlacement.ParentVehiclePlacement))
                    .WithMany()
                    .HasForeignKey(nameof(ActorPlacement.ParentVehiclePlacementId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ItemInstance>(bldr =>
            {
                bldr.HasOne(nameof(ItemInstance.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(ItemInstance.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ItemInstance.ParentVehicleInstance))
                    .WithMany()
                    .HasForeignKey(nameof(ItemInstance.ParentVehicleInstanceId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ItemInstance.ParentActorInstance))
                    .WithMany()
                    .HasForeignKey(nameof(ItemInstance.ParentActorInstanceId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ItemInstance.ParentItemInstance))
                    .WithMany()
                    .HasForeignKey(nameof(ItemInstance.ParentItemInstanceId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PersistedItem>(bldr =>
            {
                bldr.HasOne(nameof(PersistedItem.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedItem.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(PersistedItem.ParentPersistedVehicle))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedItem.ParentPersistedVehicleId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(PersistedItem.ParentPersistedActor))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedItem.ParentPersistedActorId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(PersistedItem.ParentPersistedItem))
                    .WithMany()
                    .HasForeignKey(nameof(PersistedItem.ParentPersistedItemId))
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ItemPlacement>(bldr =>
            {
                bldr.HasOne(nameof(ItemPlacement.ParentArea))
                    .WithMany()
                    .HasForeignKey(nameof(ItemPlacement.ParentAreaId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ItemPlacement.ParentVehiclePlacement))
                    .WithMany()
                    .HasForeignKey(nameof(ItemPlacement.ParentVehiclePlacementId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ItemPlacement.ParentActorPlacement))
                    .WithMany()
                    .HasForeignKey(nameof(ItemPlacement.ParentActorPlacementId))
                    .OnDelete(DeleteBehavior.Cascade);

                bldr.HasOne(nameof(ItemPlacement.ParentItemPlacement))
                    .WithMany()
                    .HasForeignKey(nameof(ItemPlacement.ParentItemPlacementId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
