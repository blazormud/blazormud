using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Core.Models.Actor;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Auth;
using BlazorMUD.Core.Models.Item;
using BlazorMUD.Core.Models.Link;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Vehicle;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorMUD.Core.Models
{
    public class ApplicationDbContext : KeyApiAuthorizationDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

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
    }
}
