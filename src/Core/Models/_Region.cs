using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMUD.Core.Models
{
    public class RegionTemplate
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "A name is requried.")]
        public string Name { get; set; } = "Unknown Region";

        // [InverseProperty(nameof(AreaTemplate.Region))]
        // public IEnumerable<AreaTemplate> Areas { get; set; } = new List<AreaTemplate>();

        // [InverseProperty(nameof(LinkTemplate.Region))]
        // public IEnumerable<LinkTemplate> Links { get; set; } = new List<LinkTemplate>();
    }
}
