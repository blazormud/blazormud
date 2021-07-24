using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMUD.Core.Models;
using BlazorMUD.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorMUD.Server.Data
{
    public class ApplicationDbContext : KeyApiAuthorizationDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<AreaTemplate> AreaTemplates { get; set; }
        public DbSet<AreaInstance> AreaInstances { get; set; }

        public DbSet<LinkTemplate> LinkTemplates { get; set; }
        public DbSet<LinkInstance> LinkInstances { get; set; }
    }
}
