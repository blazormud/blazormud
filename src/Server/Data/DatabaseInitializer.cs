using System;
using System.Linq;
using BlazorMUD.Core.Models;
using BlazorMUD.Server.Models;
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
            InitializeAreas(context);
        }

        public static void InitializeRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (roleManager.Roles.Any()) return;

            var player = new ApplicationRole { Name = "Player" };
            _ = roleManager.CreateAsync(player).Result;

            var builder = new ApplicationRole { Name = "Builder" };
            _ = roleManager.CreateAsync(builder).Result;

            var admin = new ApplicationRole { Name = "Administrator" };
            _ = roleManager.CreateAsync(admin).Result;

            var owner = new ApplicationRole { Name = "Owner" };
            _ = roleManager.CreateAsync(owner).Result;
        }

        public static void InitializeUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Any()) return;

            var owner = new ApplicationUser { UserName = "owner", Email = "owner@localhost", EmailConfirmed = true };
            var ownerResult = userManager.CreateAsync(owner, "owner").Result;
            if (ownerResult.Succeeded) userManager.AddToRoleAsync(owner, "Owner").Wait();

            var admin = new ApplicationUser { UserName = "admin", Email = "admin@localhost", EmailConfirmed = true };
            var adminResult = userManager.CreateAsync(admin, "admin").Result;
            if (adminResult.Succeeded) userManager.AddToRoleAsync(admin, "Administrator").Wait();

            var builder = new ApplicationUser { UserName = "builder", Email = "builder@localhost", EmailConfirmed = true };
            var builderResult = userManager.CreateAsync(builder, "builder").Result;
            if (builderResult.Succeeded) userManager.AddToRoleAsync(builder, "Builder").Wait();

            var player = new ApplicationUser { UserName = "player", Email = "player@localhost", EmailConfirmed = true };
            var playerResult = userManager.CreateAsync(player, "player").Result;
            if (playerResult.Succeeded) userManager.AddToRoleAsync(player, "Player").Wait();
        }

        public static void InitializeAreas(ApplicationDbContext context)
        {
            if (context.AreaTemplates.Any()) return;

            var areaTemplates = new AreaTemplate[]
            {
                new AreaTemplate { Name = "Test Area 1", Title = "Test Area 1", Description = "This is a test area."},
                new AreaTemplate { Name = "Test Area 2", Title = "Test Area 2", Description = "This is a test area."},
                new AreaTemplate { Name = "Test Area 3", Title = "Test Area 3", Description = "This is a test area."},
            };
            foreach (var template in areaTemplates)
            {
                context.AreaTemplates.Add(template);
            }
            context.SaveChanges();
        }
    }
}
