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
    public class ApplicationDbContext
        : AuthorizationDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions) { }

        public DbSet<RegionTemplate> Regions { get; set; }
        public DbSet<AreaTemplate> Areas { get; set; }

        public DbSet<LinkTemplate> LinkTemplates { get; set; }
        public DbSet<PlacedLink> PlacedLinks { get; set; }
        public DbSet<InstancedLink> InstancedLinks { get; set; }
        public DbSet<PersistedLink> PersistedLinks { get; set; }

        public DbSet<VehicleTemplate> VehicleTemplates { get; set; }
        public DbSet<PlacedVehicle> PlacedVehicles { get; set; }
        public DbSet<InstancedVehicle> InstancedVehicles { get; set; }
        public DbSet<PersistedVehicle> PersistedVehicles { get; set; }

        public DbSet<ActorTemplate> ActorTemplates { get; set; }
        public DbSet<PlacedActor> PlacedActors { get; set; }
        public DbSet<InstancedActor> InstancedActors { get; set; }
        public DbSet<PersistedActor> PersistedActors { get; set; }

        public DbSet<ItemTemplate> ItemTemplates { get; set; }
        public DbSet<PlacedItem> PlacedItems { get; set; }
        public DbSet<InstancedItem> InstancedItems { get; set; }
        public DbSet<PersistedItem> PersistedItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ! All keys need to be defined prior to defining inverse navigation properties.

            // Keys

            RegionTemplate.OnModelCreatingKeys(modelBuilder);
            AreaTemplate.OnModelCreatingKeys(modelBuilder);

            LinkTemplate.OnModelCreatingKeys(modelBuilder);
            PlacedLink.OnModelCreatingKeys(modelBuilder);
            InstancedLink.OnModelCreatingKeys(modelBuilder);
            PersistedLink.OnModelCreatingKeys(modelBuilder);

            VehicleTemplate.OnModelCreatingKeys(modelBuilder);
            PlacedVehicle.OnModelCreatingKeys(modelBuilder);
            InstancedVehicle.OnModelCreatingKeys(modelBuilder);
            PersistedVehicle.OnModelCreatingKeys(modelBuilder);

            ActorTemplate.OnModelCreatingKeys(modelBuilder);
            PlacedActor.OnModelCreatingKeys(modelBuilder);
            InstancedActor.OnModelCreatingKeys(modelBuilder);
            PersistedActor.OnModelCreatingKeys(modelBuilder);

            ItemTemplate.OnModelCreatingKeys(modelBuilder);
            PlacedItem.OnModelCreatingKeys(modelBuilder);
            InstancedItem.OnModelCreatingKeys(modelBuilder);
            PersistedItem.OnModelCreatingKeys(modelBuilder);

            // Navigation

            RegionTemplate.OnModelCreatingNavigation(modelBuilder);
            AreaTemplate.OnModelCreatingNavigation(modelBuilder);

            LinkTemplate.OnModelCreatingNavigation(modelBuilder);
            PlacedLink.OnModelCreatingNavigation(modelBuilder);
            InstancedLink.OnModelCreatingNavigation(modelBuilder);
            PersistedLink.OnModelCreatingNavigation(modelBuilder);

            VehicleTemplate.OnModelCreatingNavigation(modelBuilder);
            PlacedVehicle.OnModelCreatingNavigation(modelBuilder);
            InstancedVehicle.OnModelCreatingNavigation(modelBuilder);
            PersistedVehicle.OnModelCreatingNavigation(modelBuilder);

            ActorTemplate.OnModelCreatingNavigation(modelBuilder);
            PlacedActor.OnModelCreatingNavigation(modelBuilder);
            InstancedActor.OnModelCreatingNavigation(modelBuilder);
            PersistedActor.OnModelCreatingNavigation(modelBuilder);

            ItemTemplate.OnModelCreatingNavigation(modelBuilder);
            PlacedItem.OnModelCreatingNavigation(modelBuilder);
            InstancedItem.OnModelCreatingNavigation(modelBuilder);
            PersistedItem.OnModelCreatingNavigation(modelBuilder);
        }
    }
}
