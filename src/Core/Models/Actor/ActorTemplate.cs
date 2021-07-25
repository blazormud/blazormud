using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Actor
{
    public class ActorTemplate
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        public ActorStaticFlags StaticFlags { get; set; }
        public ActorDynamicFlags DynamicFlags { get; set; }
    }
}
