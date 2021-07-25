using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;

namespace BlazorMUD.Core.Models.Link
{
    public class PersistedLink : ILink
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public LinkTemplate Template { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey(nameof(DestinationArea))]
        public long DestinationAreaId { get; set; }
        public AreaTemplate DestinationArea { get; set; }

        public LinkStaticFlags StaticFlags { get; set; } = LinkStaticFlags.None;
        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;
    }
}
