using System;
using System.Linq;
using BlazorMUD.Core.Models;
using BlazorMUD.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Server.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(
            ApplicationDbContext context,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager
        )
        {
            context.Database.Migrate();

            InitializeRoles(roleManager);
            InitializeUsers(userManager);
            // InitializeRegion(context);
            // InitializeAreas(context);
            // InitializeLinks(context);
        }

        public static void InitializeRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (roleManager.Roles.Any()) return;

            InitializeRole("Player");
            InitializeRole("Builder");
            InitializeRole("Admin");
            InitializeRole("Owner");

            void InitializeRole(string role) =>
                roleManager.CreateAsync(new ApplicationRole { Name = role }).Wait();
        }

        public static void InitializeUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Any()) return;

            InitializeUser("owner", "Owner");
            InitializeUser("admin", "Admin");
            InitializeUser("builder1", "Builder");
            InitializeUser("builder2", "Builder");
            InitializeUser("player1", "Player");
            InitializeUser("player2", "Player");
            InitializeUser("player3", "Player");

            void InitializeUser(string username, string role)
            {
                var user = new ApplicationUser
                { UserName = username, Email = $"{username}@localhost", EmailConfirmed = true };
                var userResult = userManager.CreateAsync(user, username).Result;
                if (userResult.Succeeded) userManager.AddToRoleAsync(user, role).Wait();
            }
        }

        public static void InitializeRegion(ApplicationDbContext context)
        {
            if (context.Regions.Any()) return;

            context.Regions.Add(new RegionTemplate { Name = "Test Region A" });

            context.SaveChanges();
        }

        public static void InitializeAreas(ApplicationDbContext context)
        {
            if (context.AreaTemplates.Any()) return;

            var areaTemplates = new AreaTemplate[]
            {
                new AreaTemplate { Name = "Test Area 1", Title = "Test Area 1", Description = "This is a test area." },
                new AreaTemplate { Name = "Test Area 2", Title = "Test Area 2", Description = "This is a test area." },
                new AreaTemplate { Name = "Test Area 3", Title = "Test Area 3", Description = "This is a test area." },
            };
            foreach (var template in areaTemplates)
            {
                context.AreaTemplates.Add(template);
            }

            context.SaveChanges();
        }

        public static void InitializeLinks(ApplicationDbContext context)
        {
            if (context.LinkTemplates.Any()) return;

            var linkTemplates = new LinkTemplate[]
            {
                new LinkTemplate { SourceId = 1, DestinationId = 2 },
                new LinkTemplate { SourceId = 2, DestinationId = 1 },
                new LinkTemplate { SourceId = 2, DestinationId = 3 },
                new LinkTemplate { SourceId = 3, DestinationId = 2 },
                new LinkTemplate { SourceId = 3, DestinationId = 1 },
            };
            foreach (var template in linkTemplates)
            {
                context.LinkTemplates.Add(template);
            }

        }
    }
}
