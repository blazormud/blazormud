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

            // ! Keys and ForeignKeys need to be defined prior to defining navigation properties.

            // Keys

            new RegionTemplateEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<RegionTemplate>());
            new AreaTemplateEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<AreaTemplate>());

            new LinkTemplateEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<LinkTemplate>());
            new PlacedLinkEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PlacedLink>());
            new InstancedLinkEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<InstancedLink>());
            new PersistedLinkEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PersistedLink>());

            new VehicleTemplateEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<VehicleTemplate>());
            new PlacedVehicleEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PlacedVehicle>());
            new InstancedVehicleEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<InstancedVehicle>());
            new PersistedVehicleEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PersistedVehicle>());

            new ActorTemplateEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<ActorTemplate>());
            new PlacedActorEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PlacedActor>());
            new InstancedActorEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<InstancedActor>());
            new PersistedActorEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PersistedActor>());

            new ItemTemplateEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<ItemTemplate>());
            new PlacedItemEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PlacedItem>());
            new InstancedItemEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<InstancedItem>());
            new PersistedItemEntityTypeKeyConfiguration().Configure(modelBuilder.Entity<PersistedItem>());

            // Navigation

            new RegionTemplateEntityTypeNavConfiguration().Configure(modelBuilder.Entity<RegionTemplate>());
            new AreaTemplateEntityTypeNavConfiguration().Configure(modelBuilder.Entity<AreaTemplate>());

            new LinkTemplateEntityTypeNavConfiguration().Configure(modelBuilder.Entity<LinkTemplate>());
            new PlacedLinkEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PlacedLink>());
            new InstancedLinkEntityTypeNavConfiguration().Configure(modelBuilder.Entity<InstancedLink>());
            new PersistedLinkEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PersistedLink>());

            new VehicleTemplateEntityTypeNavConfiguration().Configure(modelBuilder.Entity<VehicleTemplate>());
            new PlacedVehicleEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PlacedVehicle>());
            new InstancedVehicleEntityTypeNavConfiguration().Configure(modelBuilder.Entity<InstancedVehicle>());
            new PersistedVehicleEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PersistedVehicle>());

            new ActorTemplateEntityTypeNavConfiguration().Configure(modelBuilder.Entity<ActorTemplate>());
            new PlacedActorEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PlacedActor>());
            new InstancedActorEntityTypeNavConfiguration().Configure(modelBuilder.Entity<InstancedActor>());
            new PersistedActorEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PersistedActor>());

            new ItemTemplateEntityTypeNavConfiguration().Configure(modelBuilder.Entity<ItemTemplate>());
            new PlacedItemEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PlacedItem>());
            new InstancedItemEntityTypeNavConfiguration().Configure(modelBuilder.Entity<InstancedItem>());
            new PersistedItemEntityTypeNavConfiguration().Configure(modelBuilder.Entity<PersistedItem>());
        }
    }
}
