using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMUD.Core.Models
{
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
