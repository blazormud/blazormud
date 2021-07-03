using System;
using System.Linq;
using BlazorMUD.Core.Models;

namespace BlazorMUD.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.AreaTemplates.Any())
            {
                return; // DB has been seeded
            }

            var areaTemplates = new AreaTemplate[]
            {
                new AreaTemplate { Name="Test Area 1", Title="Test Area 1", Description="This is a test area."},
                new AreaTemplate { Name="Test Area 2", Title="Test Area 2", Description="This is a test area."},
                new AreaTemplate { Name="Test Area 3", Title="Test Area 3", Description="This is a test area."},
            };
            foreach (var template in areaTemplates)
            {
                context.AreaTemplates.Add(template);
            }
            context.SaveChanges();
        }
    }
}
