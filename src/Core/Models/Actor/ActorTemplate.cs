using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Actor
{
    public class ActorTemplate
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        // [InverseProperty(nameof(InstancedActor.Template))]
        // public IQueryable<InstancedActor> InstancedActors { get; set; }

        // [InverseProperty(nameof(PlacedActor.Template))]
        // public IQueryable<PlacedActor> PlacedActors { get; set; }

        #endregion Relationship Properties

        public ActorStaticFlags StaticFlags { get; set; }
        public ActorDynamicFlags DynamicFlags { get; set; }
    }
}
