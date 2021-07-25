using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        // [InverseProperty(nameof(PlacedLink.Template))]
        // public IQueryable<PlacedLink> PlacedLinks { get; set; } = null;

        // [InverseProperty(nameof(InstancedLink.Template))]
        // public IQueryable<InstancedLink> InstancedLinks { get; set; } = null;

        // [InverseProperty(nameof(PersistedLink.Template))]
        // public IQueryable<PersistedLink> PersistedLinks { get; set; } = null;

        #endregion Relationship Properties

        public LinkStaticFlags StaticFlags { get; set; } = LinkStaticFlags.None;
        public LinkDynamicFlags DynamicFlags { get; set; } = LinkDynamicFlags.None;
    }
}
