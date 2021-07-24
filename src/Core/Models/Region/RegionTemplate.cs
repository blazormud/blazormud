using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BlazorMUD.Core.Models.Actor;

namespace BlazorMUD.Core.Models.Region
{
    public class RegionTemplate
    {
        [Key]
        public long Id { get; set; }

        [InverseProperty(nameof(ActorTemplate.Region))]
        public IQueryable<ActorTemplate> ActorTemplates { get; set; }
    }
}
