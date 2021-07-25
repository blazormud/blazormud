using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorMUD.Core.Models.Region;

namespace BlazorMUD.Core.Models.Link
{
    public class LinkTemplate
    {
        #region Relationship Properties

        [Key]
        public long Id { get; set; }

        [ForeignKey(nameof(Region))]
        public long RegionId { get; set; }
        public RegionTemplate Region { get; set; }

        #endregion Relationship Properties

        public LinkStaticFlags StaticFlags { get; set; } = LinkStaticFlags.None;
        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;
    }
}
