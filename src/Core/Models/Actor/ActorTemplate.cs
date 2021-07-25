using System.Linq;
using BlazorMUD.Core.Models.Region;
using Microsoft.EntityFrameworkCore;

namespace BlazorMUD.Core.Models.Actor
{
    public class ActorTemplate
    {
        #region Relationship Properties

        public long Id { get; set; }
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;
        public IQueryable<PlacedActor> PlacedActors { get; set; } = null;

        #endregion Relationship Properties

        public ActorStaticFlags StaticFlags { get; set; } = ActorStaticFlags.None;
        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;

        #region OnModelCreating

        internal static void OnModelCreatingKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorTemplate>(builder =>
            {
                builder.HasKey(nameof(ActorTemplate.Id));

                builder
                    .HasOne(nameof(ActorTemplate.Region))
                    .WithMany()
                    .HasForeignKey(nameof(ActorTemplate.RegionId))
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        internal static void OnModelCreatingNavigation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorTemplate>(builder =>
            {
                builder
                    .HasMany(nameof(ActorTemplate.InstancedActors))
                    .WithOne(nameof(InstancedActor.Template))
                    .HasForeignKey(nameof(InstancedActor.TemplateId));

                builder
                    .HasMany(nameof(ActorTemplate.PlacedActors))
                    .WithOne(nameof(PlacedActor.Template))
                    .HasForeignKey(nameof(PlacedActor.TemplateId));
            });
        }

        #endregion OnModelCreating
    }
}
