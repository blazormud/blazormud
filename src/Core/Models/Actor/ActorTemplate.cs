using System;
using System.Collections.Generic;
using System.Linq;
using BlazorMUD.Core.Models.Region;
using BlazorMUD.Core.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorMUD.Core.Models.Actor
{
    public class ActorTemplate
    {
        #region Relationship Properties

        /// <summary>
        /// Unique identifier for the actor template.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Unique identifier for the region the actor template is in.
        /// </summary>
        public long RegionId { get; set; }
        /// <summary>
        /// Refers to the region the actor template is in.
        /// </summary>
        public RegionTemplate Region { get; set; }
        /// <summary>
        /// Reference to instanced actors that use this template.
        /// </summary>
        public IQueryable<InstancedActor> InstancedActors { get; set; } = null;
        /// <summary>
        /// Reference to placed actors that use this template.
        /// </summary>
        public IQueryable<PlacedActor> PlacedActors { get; set; } = null;

        #endregion Relationship Properties

        #region World Properties

        /// <summary>
        /// Name of the actor template. Displayed in building interface.
        /// </summary>
        public string Name { get; set; } = "Unknown Object";
        /// <summary>
        /// Notes about the actor template. Displayed in building interface.
        /// </summary>
        public string Note { get; set; } = "An unknown object that is not yet described.";
        /// <summary>
        /// Short description of the actor template. Displayed in in-world lists.
        /// </summary>
        public string ShortDescription { get; set; } = "unknown object";
        /// <summary>
        /// Article used with the short description.
        /// </summary>
        public ArticleType Article { get; set; } = ArticleType.An;
        /// <summary>
        /// Long description of the actor template. Displayed when examined in-world.
        /// </summary>
        public string LongDescription { get; set; } = "An oddly shaped object of unknown origin.";
        /// <summary>
        /// A list of nouns used to refer to the actor template in priority order.
        /// </summary>
        public IEnumerable<string> Nouns { get; set; } = new string[] { "object", "unknown" };

        public ActorStaticFlags StaticFlags { get; set; } = ActorStaticFlags.None;
        public ActorDynamicFlags DynamicFlags { get; set; } = ActorDynamicFlags.None;

        #endregion World Properties

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

                builder
                    .Property(template => template.Nouns)
                    .HasConversion(
                        nouns => string.Join(',', nouns),
                        nouns => nouns.Split(',', StringSplitOptions.RemoveEmptyEntries),
                        new ValueComparer<IEnumerable<string>>(
                            (c1, c2) => c1.SequenceEqual(c2),
                            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                            c => c.ToList()));
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
