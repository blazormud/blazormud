using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMUD.Core.Models
{
    public class AreaTemplate
    {
        [Key]
        public long Id { get; set; }

        // "Cave Opening A"
        [Required(ErrorMessage = "A name is requried.")]
        public string Name { get; set; } = "Unknown Area";

        // "Cave Opening"
        [Required(ErrorMessage = "A title is requried.")]
        public string Title { get; set; } = "Unknown Area";

        // "You are in the opening of a cave. The light shines a short way into the cave, and a stinky, cool breeze is wafting from inside."
        [Required(ErrorMessage = "A description is requried.")]
        public string Description { get; set; } = "An undescribed and unknown area.";

        [InverseProperty(nameof(LinkTemplate.Source))]
        public IEnumerable<LinkTemplate> Links { get; set; }

        // [Required]
        // [ForeignKey(nameof(Region))]
        // public long RegionId { get; set; }
        // public Region Region { get; set; }
    }

    public class AreaInstance : IInstanceModel<AreaTemplate>
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public AreaTemplate Template { get; set; }

        [InverseProperty(nameof(LinkInstance.Source))]
        public IEnumerable<LinkInstance> Links { get; set; }
    }
}
