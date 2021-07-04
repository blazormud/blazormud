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

            InitializeUser(userManager,
                username: "owner",
                email: "owner@localhost",
                password: "owner",
                roles: new[] { "Owner" }
            );

            InitializeUser(userManager,
                username: "admin",
                email: "admin@localhost",
                password: "admin",
                roles: new[] { "Administrator" }
            );

            InitializeUser(userManager,
                username: "builder",
                email: "builder@localhost",
                password: "builder",
                roles: new[] { "Builder" }
            );

            InitializeUser(userManager,
                username: "player",
                email: "player@localhost",
                password: "player",
                roles: new[] { "Player" }
            );

            static void InitializeUser(
                UserManager<ApplicationUser> userManager,
                string username, string email, string password, string[] roles)
            {
                var user = new ApplicationUser { UserName = username, Email = email, EmailConfirmed = true };
                var playerResult = userManager.CreateAsync(user, password).Result;
                if (playerResult.Succeeded)
                {
                    foreach (var role in roles) userManager.AddToRoleAsync(user, role).Wait();
                }
            }
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
