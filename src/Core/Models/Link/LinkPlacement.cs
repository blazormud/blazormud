using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Area;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Link
{
    public class LinkPlacement
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Region")]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        [ForeignKey("Template")]
        public long TemplateId { get; set; }
        public LinkTemplate Template { get; set; }

        [ForeignKey("ParentArea")]
        public long ParentAreaId { get; set; }
        public AreaTemplate ParentArea { get; set; }

        [ForeignKey("DestinationArea")]
        public long DestinationAreaId { get; set; }
        public AreaTemplate DestinationArea { get; set; }
    }
}
