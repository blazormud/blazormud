using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Link
{
    public class PlacedLink
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey(nameof(Template))]
        public long TemplateId { get; set; }
        public LinkTemplate Template { get; set; }

        [ForeignKey(nameof(ParentArea))]
        public long ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey(nameof(DestinationArea))]
        public long DestinationAreaId { get; set; }
        public AreaTemplate DestinationArea { get; set; }

        #endregion Relationship Properties

        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;
    }
}
